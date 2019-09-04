﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Common.Controls.Theme;
using Common.Controls.Wizard;
using NLog;
using Vixen.Export;
using Vixen.Services;
using Vixen.Sys;

namespace VixenModules.App.TimedSequenceMapper.SequencePackageExport
{
	public partial class SequencePackageExportSummaryStage : WizardStage
	{
		private static readonly Logger Logging = LogManager.GetCurrentClassLogger();
		private readonly TimedSequencePackagerData _data;
		private bool _cancelled;
		
		public SequencePackageExportSummaryStage(TimedSequencePackagerData data)
		{
			_data = data;
			InitializeComponent();
			ThemeUpdateControls.UpdateControls(this);
			taskProgress.Minimum = 0;
			taskProgress.Maximum = 100;
			overallProgress.Minimum = 0;
			overallProgress.Maximum = 100;
			
		}

		private void ConfigureSummary()
		{
			lblSequenceCount.Text = _data.ExportSequenceFiles.Count.ToString();
			lblOutputFolder.Text = _data.ExportOutputFile;
			string audioOption = "Not included.";
			if (_data.ExportIncludeAudio)
			{
				audioOption = @"Included";
			}
			
			lblAudioOption.Text = audioOption;
		}

		
		public override void StageStart()
		{
			taskProgress.Visible = false;
			overallProgress.Visible = false;
			lblTaskProgress.Visible = false;
			lblOverallProgress.Visible = false;
			ConfigureSummary();
		}

		public override async Task StageEnd()
		{
			IProgress<ExportProgressStatus> progress = new Progress<ExportProgressStatus>(ReportProgress);
			taskProgress.Visible = true;
			overallProgress.Visible = true;
			lblTaskProgress.Visible = true;
			lblOverallProgress.Visible = true;
			await DoExport(progress);
			
			//_data.ActiveProfile = null;
		}

		public override void StageCancelled()
		{
			_cancelled = true;
		}

		private async Task<bool> DoExport(IProgress<ExportProgressStatus> progress)
		{
			var exportProgressStatus = new ExportProgressStatus();
			//Progress steps per sequence
			//Add sequence to zip
			//Discover media
			//Add media to zip
			//Add audio to zip

			//Progress for Element Tree is one to create and one to archive
			var overallProgressSteps = (_data.ExportSequenceFiles.Count * 4d) + 2;  
			var overallProgressStep = 0;

			var moduleDataFolder = Path.GetFileName(Path.GetFullPath(Paths.ModuleDataFilesPath).TrimEnd(Path.DirectorySeparatorChar));
			var mediaFolder = Path.GetFileName(Path.GetFullPath(MediaService.MediaDirectory).TrimEnd(Path.DirectorySeparatorChar));

			exportProgressStatus.OverallProgressMessage = "Overall Progress";
			progress.Report(exportProgressStatus);
			bool create = true;
			if (File.Exists(_data.ExportOutputFile))
			{
				//Ask the user!
				File.Delete(_data.ExportOutputFile);
			}

			await Task.Run(async () =>
			{
				foreach (var sequenceFile in _data.ExportSequenceFiles)
				{
					if (_cancelled)
					{
						break;
					}

					var name = Path.GetFileNameWithoutExtension(sequenceFile);
					//Progress step Add sequence to zip
					exportProgressStatus.TaskProgressValue = 0;
					exportProgressStatus.TaskProgressMessage = $"Packaging {name}"; ;
					progress.Report(exportProgressStatus);

					Archive(_data.ExportOutputFile, new List<Tuple<string, string>>{ new Tuple<string, string>(sequenceFile, Path.Combine("Sequence", Path.GetFileName(sequenceFile))) }, 
						create?ZipArchiveMode.Create:ZipArchiveMode.Update);
					create = false;

					//Progress step Discover sequence effect media
					exportProgressStatus.TaskProgressValue = 25;
					overallProgressStep++;
					exportProgressStatus.OverallProgressValue = (int)(overallProgressStep / overallProgressSteps * 100);
					exportProgressStatus.TaskProgressMessage = $"Discovering any media for {name}";
					progress.Report(exportProgressStatus);

					var effectSupportingFiles = new List<Tuple<string, string>>();
					var mediaSupportingFiles = new List<Tuple<string, string>>();

					try
					{
						var seq = XDocument.Load(sequenceFile);
						var fileElements = seq.Descendants().Where(x => x.Name.LocalName.Equals("FileName"));
						foreach (var xElement in fileElements)
						{
							if (!string.IsNullOrEmpty(xElement.Value))
							{
								var effectFiles = Directory.GetFiles(Paths.ModuleDataFilesPath, xElement.Value,
									SearchOption.AllDirectories);

								var mediaFiles = Directory.GetFiles(MediaService.MediaDirectory, xElement.Value,
									SearchOption.TopDirectoryOnly);
								
								if (effectFiles.Any())
								{
									foreach (var file in effectFiles)
									{
										effectSupportingFiles.Add(
											new Tuple<string, string>(file, 
												Path.Combine(name, moduleDataFolder, file.Replace(Paths.ModuleDataFilesPath, "").TrimStart(Path.DirectorySeparatorChar))));
									}
								}

								if (mediaFiles.Any())
								{
									foreach (var file in mediaFiles)
									{
										mediaSupportingFiles.Add(
											new Tuple<string, string>(file, 
												Path.Combine(name, mediaFolder, file.Replace(MediaService.MediaDirectory, "").TrimStart(Path.DirectorySeparatorChar))));
									}
								}
							}
						}
					}
					catch (Exception e)
					{
						Logging.Error(e, $"Exception occured parsing the sequence {sequenceFile} for media/audio file names");
					}
					
					//Add media to zip
					exportProgressStatus.TaskProgressValue = 50;
					overallProgressStep++;
					exportProgressStatus.OverallProgressValue = (int)(overallProgressStep / overallProgressSteps * 100);
					exportProgressStatus.TaskProgressMessage = $"Packaging effect media for {name}";
					progress.Report(exportProgressStatus);

					if (effectSupportingFiles.Any())
					{
						Archive(_data.ExportOutputFile, effectSupportingFiles);
					}

					//Add audio to zip
					exportProgressStatus.TaskProgressValue = 75;
					overallProgressStep++;
					exportProgressStatus.OverallProgressValue = (int)(overallProgressStep / overallProgressSteps * 100);
					exportProgressStatus.TaskProgressMessage = $"Packaging audio for {name}";
					progress.Report(exportProgressStatus);

					if (_data.ExportIncludeAudio && mediaSupportingFiles.Any())
					{
						Archive(_data.ExportOutputFile, mediaSupportingFiles);
					}

					exportProgressStatus.TaskProgressValue = 100;
					overallProgressStep++;
					exportProgressStatus.OverallProgressValue = (int)(overallProgressStep / overallProgressSteps * 100);
					progress.Report(exportProgressStatus);
					
				}

				exportProgressStatus.TaskProgressValue = 0;
				overallProgressStep++;
				exportProgressStatus.OverallProgressValue = (int)(overallProgressStep / overallProgressSteps * 100);
				exportProgressStatus.TaskProgressMessage = "Creating Profile Element Map";
				progress.Report(exportProgressStatus);

				var tempFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
				await VixenSystem.Nodes.ExportElementNodeProxy(tempFile);

				exportProgressStatus.TaskProgressValue = 50;
				overallProgressStep++;
				exportProgressStatus.OverallProgressValue = (int)(overallProgressStep / overallProgressSteps * 100);
				exportProgressStatus.TaskProgressMessage = "Archiving Profile Element Map";
				progress.Report(exportProgressStatus);

				Archive(_data.ExportOutputFile, new List<Tuple<string, string>>{new Tuple<string, string>(tempFile, Path.Combine("ProfileInfo", "ElementTree.v3e")) });

				try
				{
					File.Delete(tempFile);
				}
				catch (Exception e)
				{
					Logging.Error(e, "An error occured trying to delete the temp file.");
				}

				exportProgressStatus.TaskProgressMessage = "";
				exportProgressStatus.TaskProgressValue = 100;
				exportProgressStatus.OverallProgressValue = 100;
				exportProgressStatus.OverallProgressMessage = "Completed";
				progress.Report(exportProgressStatus);

			});
			return true;
		}

		private bool Archive(string archivePath, List<Tuple<string, string>> files, ZipArchiveMode mode = ZipArchiveMode.Update)
		{
			var success = false;
			try
			{
				using (ZipArchive archive = ZipFile.Open(archivePath, mode))
				{
					foreach (var file in files)
					{
						//if (_bw.CancellationPending)
						//{
						//	break;
						//}
						
						var addFile = Path.GetFullPath(file.Item1);
						if (addFile != archivePath)
						{
							archive.CreateEntryFromFile(file.Item1, file.Item2);
						}
						
					}
				}
				success = true;
			}
			catch (Exception ex)
			{
				Logging.Error(ex, "An error occurred adding files to archive");
				//MessageBoxForm mbf = new MessageBoxForm($"An error occurred during the zip process.\n\r {ex.Message}", "Error Zipping Files", MessageBoxButtons.OK, SystemIcons.Error);
				//mbf.ShowDialog(this);
			}

			return success;
		}

		private bool CreateDirectory(string path)
		{
			bool success = false;
			try
			{
				Directory.CreateDirectory(path);
				success = true;
			}
			catch (Exception e)
			{
				Logging.Error(e, $"An error occurred trying to create the export directory structure {path}");
			}

			return success;
		}

		
		private void ReportProgress(ExportProgressStatus progressStatus)
		{
			switch (progressStatus.StatusType)
			{
				case ExportProgressStatus.ProgressType.Both:
					UpdateTaskProgress(progressStatus);
					UpdateOverallProgress(progressStatus);
					break;
				case ExportProgressStatus.ProgressType.Task:
					UpdateTaskProgress(progressStatus);
					break;
				case ExportProgressStatus.ProgressType.Overall:
					UpdateOverallProgress(progressStatus);
					break;
			}
			
		}

		private void UpdateOverallProgress(ExportProgressStatus progressStatus)
		{
			overallProgress.Value = progressStatus.OverallProgressValue;
			lblOverallProgress.Text = progressStatus.OverallProgressMessage;
		}

		private void UpdateTaskProgress(ExportProgressStatus progressStatus)
		{
			taskProgress.Value = progressStatus.TaskProgressValue;
			lblTaskProgress.Text = progressStatus.TaskProgressMessage;
		}
	}
}
