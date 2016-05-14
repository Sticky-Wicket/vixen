﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Common.Controls.ColorManagement.ColorModels;
using Vixen.Attributes;
using Vixen.Module;
using Vixen.Sys.Attribute;
using VixenModules.App.ColorGradients;
using VixenModules.App.Curves;
using VixenModules.Effect.Pixel;
using VixenModules.EffectEditor.EffectDescriptorAttributes;
using ZedGraph;

namespace VixenModules.Effect.Picture
{
	public class Picture:PixelEffectBase
	{
		private PictureData _data;

		private double _currentGifImageNum;
		private Image _image;
		private Bitmap _scaledImage;
		private int _frameCount;
		private FrameDimension _dimension;
		private FastPixel.FastPixel _fp;
		private static Random _random = new Random();
		private bool _enableColorEffect;
		private double _movementX = 0.0;
		private double _movementY = 0.0;
		private double _position = 0.0;
		private bool _gifSpeed;
		private bool _movementRate;
		
		public Picture()
		{
			_data = new PictureData();
			UpdateAttributes();
		}

		#region Movement

		[Value]
		[ProviderCategory(@"Movement", 1)]
		[ProviderDisplayName(@"Type")]
		[ProviderDescription(@"EffectType")]
		[PropertyOrder(0)]
		public EffectType Type
		{
			get { return _data.EffectType; }
			set
			{
				_data.EffectType = value;
				IsDirty = true;
				UpdateDirectionAttribute();
				_movementRate = false;
				if (Type == EffectType.RenderPictureDownleft || Type == EffectType.RenderPictureDownright ||
				    Type == EffectType.RenderPictureUpleft || Type == EffectType.RenderPictureUpright)
				{
					_movementRate = true;
					UpdateMovementRateAttribute();
				}
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Movement", 1)]
		[ProviderDisplayName(@"Direction")]
		[ProviderDescription(@"Direction based on angle")]
		[PropertyEditor("SliderEditor")]
		[NumberRange(0, 360, 1)]
		[PropertyOrder(1)]
		public int Direction
		{
			get { return _data.Direction; }
			set
			{
				_data.Direction = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Movement", 2)]
		[ProviderDisplayName(@"Iterations")]
		[ProviderDescription(@"Iterations")]
		[PropertyEditor("SliderEditor")]
		[NumberRange(0, 20, 1)]
		[PropertyOrder(2)]
		public int Speed
		{
			get { return _data.Speed; }
			set
			{
				_data.Speed = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Movement", 1)]
		[ProviderDisplayName(@"GIF Interations")]
		[ProviderDescription(@"Number of Iterations for the Gif file")]
		[PropertyEditor("SliderEditor")]
		[NumberRange(1, 20, 1)]
		[PropertyOrder(3)]
		public int GifSpeed
		{
			get { return _data.GifSpeed; }
			set
			{
				_data.GifSpeed = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Movement", 1)]
		[ProviderDisplayName(@"XOffset")]
		[ProviderDescription(@"XOffset")]
		[PropertyEditor("SliderEditor")]
		[NumberRange(-100, 100, 1)]
		[PropertyOrder(4)]
		public int XOffset
		{
			get { return _data.XOffset; }
			set
			{
				_data.XOffset = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Movement", 1)]
		[ProviderDisplayName(@"YOffset")]
		[ProviderDescription(@"YOffset")]
		[PropertyEditor("SliderEditor")]
		[NumberRange(-100, 100, 1)]
		[PropertyOrder(5)]
		public int YOffset
		{
			get { return _data.YOffset; }
			set
			{
				_data.YOffset = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}

		#endregion

		#region Config
		[Value]
		[ProviderCategory(@"Config", 2)]
		[ProviderDisplayName(@"Orientation")]
		[ProviderDescription(@"Orientation")]
		[Browsable(false)]
		public StringOrientation Orientation
		{
			get { return _data.Orientation; }
			set
			{
				_data.Orientation = value;
				StringOrientation = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Config", 2)]
		[ProviderDisplayName(@"Filename")]
		[ProviderDescription(@"Filename")]
		[PropertyEditor("ImagePathEditor")]
		[PropertyOrder(0)]
		public String FileName
		{
			get { return _data.FileName; }
			set
			{
				_data.FileName = ConvertPath(value);
				IsDirty = true;
				if (FileName != null)
					TilePictures = TilePictures.None;
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Config", 2)]
		[ProviderDisplayName(@"Embeded Pictures")]
		[ProviderDescription(@"Embeded Pictures")]
		[PropertyOrder(1)]
		public TilePictures TilePictures
		{
			get { return _data.TilePictures; }
			set
			{
				_data.TilePictures = value;
				IsDirty = true;
				if (TilePictures != TilePictures.None)
					FileName = null;
				if (TilePictures == TilePictures.Checkers)
				{
					ColorEffect = ColorEffect.CustomColor;
				}
				UpdateColorAttribute();
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Config", 2)]
		[ProviderDisplayName(@"ScaleToGrid")]
		[ProviderDescription(@"ScaleToGrid")]
		[PropertyOrder(2)]
		public bool ScaleToGrid
		{
			get { return _data.ScaleToGrid; }
			set
			{
				_data.ScaleToGrid = value;
				IsDirty = true;
				UpdateScaleAttribute();
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Config", 2)]
		[ProviderDisplayName(@"ScalePercent")]
		[ProviderDescription(@"ScalePercent")]
		[PropertyEditor("SliderEditor")]
		[NumberRange(1, 100, 1)]
		[PropertyOrder(3)]
		public int ScalePercent
		{
			get { return _data.ScalePercent; }
			set
			{
				_data.ScalePercent = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Config", 2)]
		[ProviderDisplayName(@"Color Effect")]
		[ProviderDescription(@"ColorEffect")]
		[PropertyOrder(4)]
		public ColorEffect ColorEffect
		{
			get { return _data.ColorEffect; }
			set
			{
				_data.ColorEffect = value;
				IsDirty = true;
				UpdateColorAttribute();
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Config", 2)]
		[ProviderDisplayName(@"Enable Background Color")]
		[ProviderDescription(@"Replaces black color based on the sensitivity")]
		[PropertyOrder(5)]
		public bool EnableBackgroundColor
		{
			get { return _data.EnableBackgroundColor; }
			set
			{
				_data.EnableBackgroundColor = value;
				IsDirty = true;
				UpdateBackgroundColorAttribute();
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Config", 2)]
		[ProviderDisplayName(@"Movement Rate")]
		[ProviderDescription(@"MovementRate")]
		[PropertyEditor("SliderEditor")]
		[NumberRange(1, 20, 1)]
		[PropertyOrder(6)]
		public int MovementRate
		{
			get { return _data.MovementRate; }
			set
			{
				_data.MovementRate = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}
		#endregion

		#region String Setup properties

		[Value]
		public override StringOrientation StringOrientation
		{
			get { return _data.Orientation; }
			set
			{
				_data.Orientation = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}

		#endregion

		#region Color

		[Value]
		[ProviderCategory(@"Effect Color", 3)]
		[ProviderDisplayName(@"ColorGradient")]
		[ProviderDescription(@"Color")]
		[PropertyOrder(0)]
		public ColorGradient Colors
		{
			get { return _data.Colors; }
			set
			{
				_data.Colors = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Background", 4)]
		[ProviderDisplayName(@"Sensitivity")]
		[ProviderDescription(@"Adjusts the background color sensitivity")]
		[PropertyEditor("SliderEditor")]
		[NumberRange(1, 100, 1)]
		[PropertyOrder(1)]
		public int Sensitivity
		{
			get { return _data.Sensitivity; }
			set
			{
				_data.Sensitivity = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Background", 4)]
		[ProviderDisplayName(@"Gradient")]
		[ProviderDescription(@"Color")]
		[PropertyOrder(2)]
		public ColorGradient BackgroundColor
		{
			get { return _data.BackgroundColor; }
			set
			{
				_data.BackgroundColor = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Background", 4)]
		[ProviderDisplayName(@"Brightness")]
		[ProviderDescription(@"Brightness of the Background color")]
		[PropertyOrder(3)]
		public Curve BackgroundBrightness
		{
			get { return _data.BackgroundBrightness; }
			set
			{
				_data.BackgroundBrightness = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}

		#endregion

		#region Level properties

		[Value]
		[ProviderCategory(@"Brightness", 3)]
		[ProviderDisplayName(@"Brightness")]
		[ProviderDescription(@"Brightness")]
		public Curve LevelCurve
		{
			get { return _data.LevelCurve; }
			set
			{
				_data.LevelCurve = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}

		[Value]
		[ProviderCategory(@"Brightness", 3)]
		[ProviderDisplayName(@"Increase Brightness")]
		[ProviderDescription(@"Increase Brightness")]
		[PropertyEditor("SliderEditor")]
		[NumberRange(10, 100, 1)]
		[PropertyOrder(1)]
		public int IncreaseBrightness
		{
			get { return _data.IncreaseBrightness; }
			set
			{
				_data.IncreaseBrightness = value;
				IsDirty = true;
				OnPropertyChanged();
			}
		}

		#endregion

		private void UpdateAttributes()
		{
			UpdateColorAttribute(false);
			UpdateDirectionAttribute(false);
			UpdateBackgroundColorAttribute(false);
			UpdateGifSpeedAttribute(false);
			UpdateScaleAttribute(false);
			UpdateMovementRateAttribute(false);
			TypeDescriptor.Refresh(this);
		}

		private void UpdateColorAttribute(bool refresh = true)
		{
			_enableColorEffect = ColorEffect == ColorEffect.CustomColor;
			Dictionary<string, bool> propertyStates = new Dictionary<string, bool>(1)
			{
				{"Colors", _enableColorEffect}
			};
			SetBrowsable(propertyStates);
			if (refresh)
			{
				TypeDescriptor.Refresh(this);
			}
		}

		private void UpdateMovementRateAttribute(bool refresh = true)
		{
			Dictionary<string, bool> propertyStates = new Dictionary<string, bool>(1)
			{
				{"MovementRate", _movementRate}
			};
			SetBrowsable(propertyStates);
			if (refresh)
			{
				TypeDescriptor.Refresh(this);
			}
		}

		private void UpdateDirectionAttribute(bool refresh = true)
		{
			bool enableDirectionEffect = Type == EffectType.RenderPictureTiles;
			Dictionary<string, bool> propertyStates = new Dictionary<string, bool>(1)
			{
				{"Direction", enableDirectionEffect}
			};
			SetBrowsable(propertyStates);
			if (refresh)
			{
				TypeDescriptor.Refresh(this);
			}
		}

		private void UpdateScaleAttribute(bool refresh = true)
		{
			Dictionary<string, bool> propertyStates = new Dictionary<string, bool>(1)
			{
				{"ScalePercent", !ScaleToGrid}
			};
			SetBrowsable(propertyStates);
			if (refresh)
			{
				TypeDescriptor.Refresh(this);
			}
		}

		private void UpdateGifSpeedAttribute(bool refresh = true)
		{
			Dictionary<string, bool> propertyStates = new Dictionary<string, bool>(1)
			{
				{"GifSpeed", !_gifSpeed}
			};
			SetBrowsable(propertyStates);
			if (refresh)
			{
				TypeDescriptor.Refresh(this);
			}
		}

		private void UpdateBackgroundColorAttribute(bool refresh = true)
		{
			Dictionary<string, bool> propertyStates = new Dictionary<string, bool>(3)
			{
				{"BackgroundBrightness", EnableBackgroundColor},
				{"BackgroundColor", EnableBackgroundColor},
				{"Sensitivity", EnableBackgroundColor}
			};
			SetBrowsable(propertyStates);
			if (refresh)
			{
				TypeDescriptor.Refresh(this);
			}
		}

		public override IModuleDataModel ModuleData
		{
			get { return _data; }
			set
			{
				_data = value as PictureData;
				UpdateAttributes();
				IsDirty = true;
			}
		}

		private string ConvertPath(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return path;
			}
			if (Path.IsPathRooted(path))
			{
				return CopyLocal(path);
			}
			
			return path;
		}

		private string CopyLocal(string path)
		{
			string name = Path.GetFileName(path);
			var destPath = Path.Combine(PictureDescriptor.ModulePath, name);
			if (path != destPath)
			{
				File.Copy(path, destPath, true);
			}
			return name;
		}
		
		protected override void SetupRender()
		{
			if (_scaledImage != null)
			{
				_scaledImage.Dispose();
			}
			if (!string.IsNullOrEmpty(FileName))
			{
				var filePath = Path.Combine(PictureDescriptor.ModulePath, FileName);
				if (File.Exists(filePath))
				{
					using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
					{
						var ms = new MemoryStream();
						fs.CopyTo(ms);
						ms.Position = 0;
						if (_image != null) _image.Dispose();
						_image = Image.FromStream(ms);
					}

				}
			}
			else
			{
				var fs =
					   typeof(Picture).Assembly.GetManifestResourceStream("VixenModules.Effect.Picture.PictureTiles." +
																			   TilePictures + ".png");
				_image = Image.FromStream(fs);
			}
			if (_image != null)
			{
				_dimension = new FrameDimension(_image.FrameDimensionsList[0]);
				// Number of frames
				_frameCount = _image.GetFrameCount(_dimension);
				_gifSpeed = true;
				if (_frameCount > 1)
				{
					_gifSpeed = false;
				}
				UpdateGifSpeedAttribute();
				if (BackgroundBrightness == null) //This will only be null for Picture effects that are already on the time line. This is due to the upgrade for the effect.
				{
					BackgroundBrightness = new Curve(new PointPairList(new[] {0.0, 100}, new[] {50.0, 50.0}));
					Colors = new ColorGradient(Color.DodgerBlue);
					BackgroundColor = new ColorGradient(Color.Red);
					Sensitivity = 15;
					Direction = 0;
					IncreaseBrightness = 10;
					GifSpeed = 1;
					EnableBackgroundColor = false;
					ColorEffect = ColorEffect.None;
					MovementRate = 4;
				}
			}
			_movementX = 0.0;
			_movementY = 0.0;
		}

		protected override void CleanUpRender()
		{
			_dimension = null;
			if (_scaledImage != null)
			{
				_scaledImage.Dispose();
			}
			if (_image != null)
			{
				_image.Dispose();
			}
		}

		protected override void RenderEffect(int frame, IPixelFrameBuffer frameBuffer)
		{
			var dir = 360 - Direction;
			double level = LevelCurve.GetValue(GetEffectTimeIntervalPosition(frame) * 100) / 100;
			int speedFactor = 4;
			int state = MovementRate * frame;
			if (Type != EffectType.RenderPictureTiles && Type != EffectType.RenderPictureNone)
			{
				_position = ((GetEffectTimeIntervalPosition(frame) * Speed) % 1);
			}
			else if (frame == 0)
			{
				_position = ((GetEffectTimeIntervalPosition(frame + 1) * Speed) % 1);
			}

			CalculateImageNumberByPosition((GetEffectTimeIntervalPosition(frame)*GifSpeed)%1);
			_image.SelectActiveFrame(_dimension, (int) _currentGifImageNum);
			_scaledImage = ScaleToGrid
				? ScalePictureImage(_image, BufferWi, BufferHt)
				: ScaleImage(_image, (double) ScalePercent/100);

			if (ColorEffect == ColorEffect.GreyScale)
			{
				_scaledImage = (Bitmap) ConvertToGrayScale(_scaledImage);
			}
			_fp = new FastPixel.FastPixel(_scaledImage);

			if (_fp != null)
			{
				int imageWidth = _fp.Width;
				int imageHeight = _fp.Height;
				double deltaX = 0;
				double deltaY = 0;
				double angleOffset;

				if (dir > 45 && dir <= 90)
					angleOffset = -(dir - 90);
				else if (dir > 90 && dir <= 135)
					angleOffset = dir - 90;
				else if (dir > 135 && dir <= 180)
					angleOffset = -(dir - 180);
				else if (dir > 180 && dir <= 225)
					angleOffset = dir - 180;
				else if (dir > 225 && dir <= 270)
					angleOffset = -(dir - 270);
				else if (dir > 270 && dir <= 315)
					angleOffset = dir - 270;
				else if (dir > 315 && dir <= 360)
					angleOffset = -(dir - 360);
				else
					angleOffset = dir;

				double imageSpeed = _position*(imageWidth/(Math.Cos((Math.PI/180)*angleOffset)));

				//Moving left and right
				if (dir > 0 && dir <= 90)
				{
					deltaX = ((double) dir/90)*(imageSpeed);
				}
				else if (dir > 90 && dir <= 180)
				{
					deltaX = ((double) Math.Abs(dir - 180)/90)*(imageSpeed);
				}
				else if (dir > 180 && dir <= 270)
				{
					deltaX = -1*(((double) Math.Abs(dir - 180)/90)*(imageSpeed));
				}
				else if (dir > 270 && dir <= 360)
				{
					deltaX = -1*(((double) Math.Abs(dir - 360)/90)*(imageSpeed));
				}

				//Moving up and down
				if (dir >= 0 && dir <= 90)
				{
					deltaY = (((double) Math.Abs(dir - 90)/90))*(imageSpeed);
				}
				else if (dir > 90 && dir <= 180)
				{
					deltaY = -1*(((double) Math.Abs(dir - 90)/90)*(imageSpeed));
				}
				else if (dir > 180 && dir <= 270)
				{
					deltaY = -1*(((double) Math.Abs(dir - 270)/90)*(imageSpeed));
				}
				else if (dir > 270 && dir <= 360)
				{
					deltaY = ((double) Math.Abs(270 - dir)/90)*(imageSpeed);
				}

				_movementX += deltaX;
				_movementY += deltaY;

				_fp.Lock();
				Color fpColor = new Color();

				int yoffset = (BufferHt + imageHeight)/2;
				int xoffset = (imageWidth - BufferWi)/2;
				int xOffsetAdj = XOffset*BufferWi/100;
				int yOffsetAdj = YOffset*BufferHt/100;
				int imageHt = imageHeight;
				int imageWi = imageWidth;

				switch (Type)
				{
					case EffectType.RenderPicturePeekaboo0:
					case EffectType.RenderPicturePeekaboo180:
						//Peek a boo
						yoffset = -(BufferHt) + (int) ((BufferHt + 5)*_position*2);
						if (yoffset > 10)
						{
							yoffset = -yoffset + 10; //reverse direction
						}
						else if (yoffset >= -1)
						{
							yoffset = -1; //pause in middle
						}
						break;
					case EffectType.RenderPictureWiggle:
						if (_position >= 0.5)
						{
							xoffset += (int) (BufferWi*((1.0 - _position)*2.0 - 0.5));
						}
						else
						{
							xoffset += (int) (BufferWi*(_position*2.0 - 0.5));
						}
						break;
					case EffectType.RenderPicturePeekaboo90: //peekaboo 90
					case EffectType.RenderPicturePeekaboo270: //peekaboo 270
						if (Orientation == StringOrientation.Vertical)
						{
							yoffset = (imageHt - BufferWi)/2; //adjust offsets for other axis
						}
						else
						{
							yoffset = (imageWi - BufferHt)/2; //adjust offsets for other axis	
						}

						if (Orientation == StringOrientation.Vertical)
						{
							xoffset = -(BufferHt) + (int) ((BufferHt + 5)*_position*2);
						}
						else
						{
							xoffset = -(BufferWi) + (int) ((BufferWi + 5)*_position*2);
						}
						if (xoffset > 10)
						{
							xoffset = -xoffset + 10; //reverse direction
						}
						else if (xoffset >= -1)
						{
							xoffset = -1; //pause in middle
						}

						break;
					case EffectType.RenderPictureTiles:
						imageHt = BufferHt;
						imageWi = BufferWi;
						break;

				}
				for (int x = 0; x < imageWi; x++)
				{
					for (int y = 0; y < imageHt; y++)
					{
						if (Type != EffectType.RenderPictureTiles) // change this so only when tiles are disabled
						{
							fpColor = _fp.GetPixel(x, y);
						}

						var hsv = HSV.FromRGB(fpColor);
						double tempV = hsv.V*level*((double) (IncreaseBrightness)/10);
						if (tempV > 1)
							tempV = 1;
						hsv.V = tempV;

						switch (Type)
						{
							case EffectType.RenderPicturePeekaboo0:

								if (fpColor != Color.Transparent)
								{
									//Peek a boo
									hsv = CustomColor(hsv, frame, level, fpColor);
									frameBuffer.SetPixel(x - xoffset + xOffsetAdj, BufferHt + yoffset - y + yOffsetAdj, hsv);
								}
								break;
							case EffectType.RenderPictureWiggle:
								hsv = CustomColor(hsv, frame, level, fpColor);
								frameBuffer.SetPixel(x + xoffset + xOffsetAdj, yoffset - y + yOffsetAdj, hsv);
								break;
							case EffectType.RenderPicturePeekaboo90:
								hsv = CustomColor(hsv, frame, level, fpColor);
								frameBuffer.SetPixel(BufferWi + xoffset - y + xOffsetAdj, x - yoffset + yOffsetAdj, hsv);
								break;
							case EffectType.RenderPicturePeekaboo180:
								hsv = CustomColor(hsv, frame, level, fpColor);
								frameBuffer.SetPixel(x - xoffset + xOffsetAdj, y - yoffset + yOffsetAdj, hsv);
								break;
							case EffectType.RenderPicturePeekaboo270:
								hsv = CustomColor(hsv, frame, level, fpColor);
								frameBuffer.SetPixel(y - xoffset + xOffsetAdj, BufferHt + yoffset - x + yOffsetAdj, hsv);
								break;
							case EffectType.RenderPictureLeft:
								// left
								int leftX = x + (BufferWi - (int) (_position*(imageWi + BufferWi)));
								hsv = CustomColor(hsv, frame, level, fpColor);
								frameBuffer.SetPixel(leftX + xOffsetAdj, yoffset - y + yOffsetAdj, hsv);
								break;
							case EffectType.RenderPictureRight:
								// right
								int rightX = x + -imageWi + (int) (_position*(imageWi + BufferWi));
								hsv = CustomColor(hsv, frame, level, fpColor);
								frameBuffer.SetPixel(rightX + xOffsetAdj, yoffset - y + yOffsetAdj, hsv);
								break;
							case EffectType.RenderPictureUp:
								// up
								int upY = (int) ((imageHt + BufferHt)*_position) - y;
								hsv = CustomColor(hsv, frame, level, fpColor);
								frameBuffer.SetPixel(x - xoffset + xOffsetAdj, upY + yOffsetAdj, hsv);
								break;

							case EffectType.RenderPictureUpleft:
								int upLeftY = (int) ((imageHt + BufferHt)*_position) - y;
								hsv = CustomColor(hsv, frame, level, fpColor);
								frameBuffer.SetPixel(
									Convert.ToInt32(x + BufferWi - (state % ((imageWi + BufferWi) * speedFactor)) / speedFactor) + xOffsetAdj,
									upLeftY + yOffsetAdj, hsv);
								break; // up-left
							case EffectType.RenderPictureDownleft:
								int downLeftY = BufferHt + imageHt - (int) ((imageHt + BufferHt)*_position) - y;
								hsv = CustomColor(hsv, frame, level, fpColor);
								frameBuffer.SetPixel(
									Convert.ToInt32(x + BufferWi - (state % ((imageWi + BufferWi) * speedFactor)) / speedFactor) + xOffsetAdj,
									downLeftY + yOffsetAdj, hsv);
								break; // down-left
							case EffectType.RenderPictureUpright:
								int upRightY = (int) ((imageHt + BufferHt)*_position) - y;
								hsv = CustomColor(hsv, frame, level, fpColor);
								frameBuffer.SetPixel(
									Convert.ToInt32(x + (state % ((imageWi + BufferWi) * speedFactor)) / speedFactor - imageWi) + xOffsetAdj,
									upRightY + yOffsetAdj, hsv);
								break; // up-right
							case EffectType.RenderPictureDownright:
								int downRightY = BufferHt + imageHt - (int) ((imageHt + BufferHt)*_position) - y;
								hsv = CustomColor(hsv, frame, level, fpColor);
								frameBuffer.SetPixel(
									Convert.ToInt32(x + (state % ((imageWi + BufferWi) * speedFactor)) / speedFactor - imageWi) + xOffsetAdj,
									downRightY + yOffsetAdj, hsv);
								break; // down-right
							case EffectType.RenderPictureDown:
								// down
								int downY = (BufferHt + imageHt - 1) - (int) ((imageHt + BufferHt)*_position) - y;
								hsv = CustomColor(hsv, frame, level, fpColor);
								frameBuffer.SetPixel(x - xoffset + xOffsetAdj, downY + yOffsetAdj, hsv);
								break;
							case EffectType.RenderPictureNone:
								hsv = CustomColor(hsv, frame, level, fpColor);
								frameBuffer.SetPixel(x - xoffset + xOffsetAdj, yoffset - y + yOffsetAdj, hsv);
								break;
							case EffectType.RenderPictureTiles:
								int colorX = x + Convert.ToInt32(_movementX) - (XOffset*BufferWi/100);
								int colorY = y + Convert.ToInt32(_movementY) + (YOffset*BufferHt/100);

								if (colorX >= 0)
								{
									colorX = colorX%imageWidth;
								}
								else if (colorX < 0)
								{
									colorX = Convert.ToInt32(colorX%imageWidth) + imageWidth - 1;
								}

								if (colorY >= 0)
								{
									colorY = Convert.ToInt32((colorY%imageHeight));
								}
								else if (colorY < 0)
								{
									colorY = Convert.ToInt32(colorY%imageHeight) + imageHeight - 1;
								}
								if (colorX <= _fp.Width && colorY <= _fp.Height)
								{
									fpColor = _fp.GetPixel(colorX, colorY);

									hsv = HSV.FromRGB(fpColor);
									hsv = CustomColor(hsv, frame, level, fpColor);
									frameBuffer.SetPixel(x, BufferHt - y - 1, hsv);
								}
								break;
						}
					}
				}
				_fp.Unlock(false);
				_fp.Dispose();
				_scaledImage.Dispose();
			}
		}

		private HSV CustomColor(HSV hsv, int frame, double level, Color fpColor)
		{
			double backgroundLevel = BackgroundBrightness.GetValue(GetEffectTimeIntervalPosition(frame) * 100) / 100;
			double backgroundSensitivity = Sensitivity;
			if (hsv.V >= backgroundSensitivity / 100)
			{
				if (ColorEffect == ColorEffect.CustomColor)
				{
					Color newColor = new Color();
					newColor = _data.Colors.GetColorAt((GetEffectTimeIntervalPosition(frame) * 100) / 100);
					double hsvLevel = Convert.ToInt32(fpColor.GetBrightness() * 255);
					hsv = HSV.FromRGB(newColor);
					hsv.V = hsvLevel / 100;
				}

				double tempV = hsv.V * level * ((double)(IncreaseBrightness) / 10);
				if (tempV > 1)
					tempV = 1;
				hsv.V = tempV;
			}
			else
			{
				//Background color
				if (EnableBackgroundColor)
				{
					fpColor = BackgroundColor.GetColorAt((GetEffectTimeIntervalPosition(frame) * 100) / 100);
					hsv = HSV.FromRGB(fpColor);
					hsv.V = hsv.V * backgroundLevel * level;
				}
			}
			
			return hsv;
		}

		private void CalculateImageNumberByPosition(double position)
		{
			_currentGifImageNum = Math.Round(position*(_frameCount-1));
		}

		public static Bitmap ScalePictureImage(Image image, int maxWidth, int maxHeight)
		{
			var ratioX = (double)maxWidth / image.Width;
			var ratioY = (double)maxHeight / image.Height;
			var ratio = Math.Min(ratioX, ratioY);
			var newWidth = (int)(image.Width * ratio);
			var newHeight = (int)(image.Height * ratio);
			if (newHeight <= 0) newHeight = 1;
			if (newWidth <= 0) newWidth = 1;
			var newImage = new Bitmap(newWidth, newHeight);
			Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
			return newImage;
		}

		public Bitmap ScaleImage(Image image, double scale)
		{
			int maxWidth = Convert.ToInt32((double)image.Width * scale);
			int maxHeight = Convert.ToInt32((double)image.Height * scale);
			var ratioX = (double)maxWidth / image.Width;
			var ratioY = (double)maxHeight / image.Height;
			var ratio = Math.Min(ratioX, ratioY);

			var newWidth = (int)(image.Width * ratio);
			var newHeight = (int)(image.Height * ratio);

			var newImage = new Bitmap(newWidth, newHeight);
			using (var g = Graphics.FromImage(newImage))
			{
				g.DrawImage(image, 0, 0, newWidth, newHeight);
				return newImage;
			}
		}

		public static Image ConvertToGrayScale(Image srce)
		{
			Bitmap bmp = new Bitmap(srce.Width, srce.Height);
			using (Graphics gr = Graphics.FromImage(bmp))
			{
				var matrix = new float[][]
				             	{
				             		new float[] {0.299f, 0.299f, 0.299f, 0, 0},
				             		new float[] {0.587f, 0.587f, 0.587f, 0, 0},
				             		new float[] {0.114f, 0.114f, 0.114f, 0, 0},
				             		new float[] {0, 0, 0, 1, 0},
				             		new float[] {0, 0, 0, 0, 1}
				             	};
				var ia = new System.Drawing.Imaging.ImageAttributes();
				ia.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(matrix));
				var rc = new Rectangle(0, 0, srce.Width, srce.Height);
				gr.DrawImage(srce, rc, 0, 0, srce.Width, srce.Height, GraphicsUnit.Pixel, ia);
				return bmp;
			}
		}

		public static bool IsPictureTileResource(string s)
		{
			return s.Contains("VixenModules.Effect.Picture.PictureTiles");
		}
	}
}
