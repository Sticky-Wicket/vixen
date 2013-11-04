﻿//=====================================================================
//
//	OutputPlugin - E1.31 Plugin for Vixen 3.0
//
//		The original base code was generated by Visual Studio based
//		on the interface specification intrinsic to the Vixen plugin
//		technology. All other comments and code are the work of the
//		author. Some comments are based on the fundamental work
//		gleaned from published works by others in the Vixen community
//		including those of Jonathon Reinhart.
//
//=====================================================================

//=====================================================================
//
// Copyright (c) 2010 Joshua 1 Systems Inc. All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are
// permitted provided that the following conditions are met:
//
//    1. Redistributions of source code must retain the above copyright notice, this list of
//       conditions and the following disclaimer.
//
//    2. Redistributions in binary form must reproduce the above copyright notice, this list
//       of conditions and the following disclaimer in the documentation and/or other materials
//       provided with the distribution.
//
// THIS SOFTWARE IS PROVIDED BY JOSHUA 1 SYSTEMS INC. "AS IS" AND ANY EXPRESS OR IMPLIED
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
// ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
// ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// The views and conclusions contained in the software and documentation are those of the
// authors and should not be interpreted as representing official policies, either expressed
// or implied, of Joshua 1 Systems Inc.
//
//=====================================================================

using Vixen.Sys;

namespace VixenModules.Controller.E131
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using Vixen.Commands;
    using Vixen.Module.Controller;
    using VixenModules.Controller.E131.J1Sys;
    using VixenModules.Output.E131;
    using System.Linq;
    // -----------------------------------------------------------------
    // 
    // OutputPlugin - the output plugin class for vixen
    // 
    // -----------------------------------------------------------------

    public class E131OutputPlugin : ControllerModuleInstanceBase
    {
        // our option settings

        private E131ModuleDataModel _data;

        public override Vixen.Module.IModuleDataModel ModuleData
        {

            get
            {
                return _data;
            }
            set
            {
                _data = (E131ModuleDataModel)value;
            }
        }


        private int _eventCnt;


        // a stringbuilder to store warnings, errors, and statistics
        private StringBuilder _messageTexts;

        // a table of UniverseEntry objects to hold all universes

        // a sorted list of NetworkInterface object to use for sockets
        private SortedList<string, NetworkInterface> _nicTable;

        private long _totalTicks;





        private bool isSetupOpen;
        private bool hasStarted;

        public E131OutputPlugin()
        {
            DataPolicyFactory = new DataPolicyFactory();
            isSetupOpen = false;
            hasStarted = false;
        }

        public void Initialize()
        {
            // load all of our xml into working objects
            this.LoadSetupNodeInfo();

            // find all of the network interfaces & build a sorted list indexed by Id
            this._nicTable = new SortedList<string, NetworkInterface>();

            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var nic in nics)
            {
                if (nic.NetworkInterfaceType.CompareTo(NetworkInterfaceType.Tunnel) != 0)
                {
                    this._nicTable.Add(nic.Id, nic);
                }
            }
            _data.Universes.ForEach(u =>
            {
                if (!E131OutputPlugin.EmployedUniverses.Contains(u.Universe))
                    E131OutputPlugin.EmployedUniverses.Add(u.Universe);
            });
        }

        // -------------------------------------------------------------
        // 
        // 	Setup() - called when the user has requested to setup
        // 			  the plugin instance
        // 
        // -------------------------------------------------------------
        public override bool Setup()
        {
            //initialize setupNode


            //Initialize();
            isSetupOpen = true;



            // define/create objects

            using (var setupForm = new SetupForm())
            {
                // Tell the setupForm our output count
                setupForm.PluginChannelCount = this.OutputCount;

                List<int> initialUniverseList = new List<int>();
                // for each universe add it to setup form
                foreach (var uE in _data.Universes)
                {
                    setupForm.UniverseAdd(
                        uE.Active, uE.Universe, uE.Start + 1, uE.Size, uE.Unicast, uE.Multicast, uE.Ttl);

                    if (!E131OutputPlugin.EmployedUniverses.Contains(uE.Universe))
                        E131OutputPlugin.EmployedUniverses.Add(uE.Universe);

                    initialUniverseList.Add(uE.Universe);
                }



                setupForm.WarningsOption = _data.Warnings;
                setupForm.StatisticsOption = _data.Statistics;
                setupForm.EventRepeatCount = _data.EventRepeatCount;


                if (setupForm.ShowDialog() == DialogResult.OK)
                {


                    _data.Warnings = setupForm.WarningsOption;
                    _data.Statistics = setupForm.StatisticsOption;
                    _data.EventRepeatCount = setupForm.EventRepeatCount;
                    _data.Universes.Clear();

                    initialUniverseList.ForEach(u => E131OutputPlugin.EmployedUniverses.RemoveAll(t => u == t));

                    // add each of the universes as a child
                    for (int i = 0; i < setupForm.UniverseCount; i++)
                    {
                        bool active = true;
                        int universe = 0;
                        int start = 0;
                        int size = 0;
                        string unicast = string.Empty;
                        string multicast = string.Empty;
                        int ttl = 0;

                        if (setupForm.UniverseGet(
                            i, ref active, ref universe, ref start, ref size, ref unicast, ref multicast, ref ttl))
                        {
                            _data.Universes.Add(new UniverseEntry(i, active, universe, start - 1, size, unicast, multicast, ttl));
                            //Only add the universe if it doesnt already exist
                            if (!E131OutputPlugin.EmployedUniverses.Contains(universe))
                                E131OutputPlugin.EmployedUniverses.Add(universe);
                        }
                    }

                    hasStarted = false; //prevent updates

                    // update in memory table to match xml
                    this.Shutdown();
                    this.Start();
                }
            }

            isSetupOpen = false;

            return true;
        }

        internal static List<int> EmployedUniverses = new List<int>();

        public override bool HasSetup
        {
            get { return true; }
        }

        // -------------------------------------------------------------
        // 
        // 	Shutdown() - called when execution is stopped or the
        // 				 plugin instance is no longer going to be
        // 				 referenced
        // 
        // -------------------------------------------------------------
        public void Shutdown()
        {
            // keep track of interface ids we have shutdown
            var idList = new SortedList<string, int>();

            // iterate through universetable
            foreach (var uE in _data.Universes)
            {
                // assume multicast
                string id = uE.Multicast;

                // if unicast use psuedo id
                if (uE.Unicast != null)
                {
                    id = "unicast";
                }

                // if active
                if (uE.Active)
                {
                    // and a usable socket
                    if (uE.Socket != null)
                    {
                        // if not already done
                        if (!idList.ContainsKey(id))
                        {
                            // record it & shut it down
                            idList.Add(id, 1);
                            uE.Socket.Shutdown(SocketShutdown.Both);
                            uE.Socket.Close();
                        }
                    }
                }
            }


            if (_data.Statistics)
            {
                if (this._messageTexts.Length > 0)
                {
                    this._messageTexts.AppendLine();
                }

                this._messageTexts.AppendLine(string.Format("Events: {0}" + this._eventCnt));
                this._messageTexts.AppendLine(string.Format("Total Time: {0} Ticks; {1} ms", this._totalTicks, TimeSpan.FromTicks(this._totalTicks).Milliseconds));

                foreach (var uE in _data.Universes)
                {
                    if (uE.Active)
                    {
                        this._messageTexts.AppendLine();
                        this._messageTexts.Append(uE.StatsToText);
                    }
                }

                J1MsgBox.ShowMsg(
                    "Plugin Statistics:",
                    this._messageTexts.ToString(),
                    "J1Sys E1.31 Vixen Plugin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            // this._universeTable.Clear();
            if (this._nicTable != null) this._nicTable.Clear();
            this._nicTable = new  SortedList<string, NetworkInterface>();  
        }

        // -------------------------------------------------------------
        // 
        // 	Startup() - called when the plugin is loaded
        // 
        // 
        // 	todo:
        // 
        // 		1) probably add error checking on all 'new' operations
        // 		and system calls
        // 
        // 		2) better error reporting and logging
        //
        //      3) Sequence # should be per universe
        // 	
        // -------------------------------------------------------------
        public override void Start()
        {
            // working copy of networkinterface object
            NetworkInterface networkInterface;

            // a single socket to use for unicast (if needed)
            Socket unicastSocket = null;

            // working ipaddress object
            IPAddress ipAddress = null;

            // a sortedlist containing the multicast sockets we've already done
            var nicSockets = new SortedList<string, Socket>();

            // Load the NICs and XML file
            this.Initialize();

            // initialize plugin wide stats
            this._eventCnt = 0;
            this._totalTicks = 0;

            // initialize messageTexts stringbuilder to hold all warnings/errors
            this._messageTexts = new StringBuilder();


            // now we need to scan the universeTable
            foreach (var uE in _data.Universes)
            {
                // if it's still active we'll look into making a socket for it
                if (uE.Active)
                {
                    // if it's unicast it's fairly easy to do
                    if (uE.Unicast != null)
                    {
                        // is this the first unicast universe?
                        if (unicastSocket == null)
                        {
                            // yes - make a new socket to use for ALL unicasts
                            unicastSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                        }

                        // use the common unicastsocket
                        uE.Socket = unicastSocket;

                        // try to parse our ip address
                        if (!IPAddress.TryParse(uE.Unicast, out ipAddress))
                        {
                            // oops - bad ip, fuss and deactivate
                            uE.Active = false;
                            uE.Socket = null;
                            this._messageTexts.AppendLine(string.Format("Invalid Unicast IP: {0} - {1}", uE.Unicast, uE.RowUnivToText));
                        }
                        else
                        {
                            // if good, make our destination endpoint
                            uE.DestIpEndPoint = new IPEndPoint(ipAddress, 5568);
                        }
                    }

                    // if it's multicast roll up your sleeves we've got work to do
					else if (uE.Multicast != null)
					{
						// create an ipaddress object based on multicast universe ip rules
						var multicastIpAddress =
							new IPAddress(new byte[] { 239, 255, (byte)(uE.Universe >> 8), (byte)(uE.Universe & 0xff) });

						// create an ipendpoint object based on multicast universe ip/port rules
						var multicastIpEndPoint = new IPEndPoint(multicastIpAddress, 5568);

						// first check for multicast id in nictable
						if (!this._nicTable.ContainsKey(uE.Multicast))
						{
							// no - deactivate and scream & yell!!
							uE.Active = false;
							this._messageTexts.AppendLine(string.Format("Invalid Multicast NIC ID: {0} - {1}", uE.Multicast, uE.RowUnivToText));
						}
						else
						{
							// yes - let's get a working networkinterface object
							networkInterface = this._nicTable[uE.Multicast];

							// have we done this multicast id before?
							if (nicSockets.ContainsKey(uE.Multicast))
							{
								// yes - easy to do - use existing socket
								uE.Socket = nicSockets[uE.Multicast];

								// setup destipendpoint based on multicast universe ip rules
								uE.DestIpEndPoint = multicastIpEndPoint;
							}
							// is the interface up?
							else if (networkInterface.OperationalStatus != OperationalStatus.Up)
							{
								// no - deactivate and scream & yell!!
								uE.Active = false;
								this._messageTexts.AppendLine(string.Format("Multicast Interface Down: {0} - {1}", networkInterface.Name , uE.RowUnivToText));
							}
							else
							{
								// new interface in 'up' status - let's make a new udp socket
								uE.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

								// get a working copy of ipproperties
								IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();

								// get a working copy of all unicasts
								UnicastIPAddressInformationCollection unicasts = ipProperties.UnicastAddresses;


								ipAddress = null;

								foreach (var unicast in unicasts)
								{
									if (unicast.Address.AddressFamily == AddressFamily.InterNetwork)
									{
										ipAddress = unicast.Address;
									}
								}

								if (ipAddress == null)
								{
									this._messageTexts.AppendLine(string.Format("No IP On Multicast Interface: {0} - {1}" , networkInterface.Name , uE.InfoToText));
								}
								else
								{
									// set the multicastinterface option
									uE.Socket.SetSocketOption(
										SocketOptionLevel.IP,
										SocketOptionName.MulticastInterface,
										ipAddress.GetAddressBytes());

									// set the multicasttimetolive option
									uE.Socket.SetSocketOption(
										SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, uE.Ttl);

									// setup destipendpoint based on multicast universe ip rules
									uE.DestIpEndPoint = multicastIpEndPoint;

									// add this socket to the socket table for reuse
									nicSockets.Add(uE.Multicast, uE.Socket);
								}
							}
						}
					}
					else
					{
						throw new System.Exception("no uni or multi cast");
					}

                    // if still active we need to create an empty packet
                    if (uE.Active)
                    {
                        var zeroBfr = new byte[uE.Size];
                        var e131Packet = new E131Packet(_data.ModuleInstanceId, string.Empty, 0, (ushort)uE.Universe, zeroBfr, 0, uE.Size);
                        uE.PhyBuffer = e131Packet.PhyBuffer;
                    }
                }
                hasStarted = true;
            }

            // any warnings/errors recorded?
            if (this._messageTexts.Length > 0)
            {
                // should we display them
                if (_data.Warnings)
                {
                    // show our warnings/errors
                    J1MsgBox.ShowMsg(
                        "The following warnings and errors were detected during startup:",
                        this._messageTexts.ToString(),
                        "Startup Warnings/Errors",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);

                    // discard warning/errors after reporting them
                    this._messageTexts = new StringBuilder();
                }
            }


#if VIXEN21
			return new List<Form> {};
#endif
        }

        private E131ModuleDataModel GetDataModel()
        {
            return (E131ModuleDataModel)this.ModuleData;
        }

        ConcurrentDictionary<int, DateTime> outputStateDictionary = new ConcurrentDictionary<int, DateTime>();

        public override void UpdateState(int chainIndex, ICommand[] outputStates)
        {
            UpdateState(chainIndex, outputStates.ToChannelValuesAsBytes());
        }



        public void UpdateState(int chainIndex, byte[] channelValues)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            //Make sure the setup form is closed & the plugin has started
            if (isSetupOpen && hasStarted)
            {
                return;
            }
            DateTime lastUpdate;

            if (channelValues.Where(w => w == 0).Count() == channelValues.Length)
            {

                if (outputStateDictionary.TryGetValue(chainIndex, out lastUpdate))
                {
                    return;
                }
                else
                    outputStateDictionary[chainIndex] = DateTime.Now;
            }
            else
            {
                outputStateDictionary.TryRemove(chainIndex, out lastUpdate);
            }
            int universeSize = 0;

            this._eventCnt++;

            if (_data.Universes == null || _data.Universes.Count == 0)
            {
                return;
            }

            foreach (var uE in _data.Universes)
            {
                //Check if the universe is active and inside a valid channel range
                if (uE.Active && (uE.Start + 1) <= OutputCount)
                {
                    //Check the universe size boundary.
                    if ((uE.Start + 1 + uE.Size) > OutputCount)
                    {
                        universeSize = OutputCount - uE.Start - 1;
                    }
                    else
                    {
                        universeSize = uE.Size;
                    }


                    //Reduce duplicate packets
                    //SeqNumbers are per universe so that they can run independently
                    if (_data.EventRepeatCount > 0)
                    {
                        if (uE.EventRepeatCount-- > 0)
                        {
                            if (E131Packet.CompareSlots(uE.PhyBuffer, channelValues, uE.Start, universeSize))
                            {
                                continue;
                            }
                        }
                    }


                    //Not sure why this is needed, but the plugin will crash after being reconfigured otherwise.
                    if (uE.PhyBuffer != null)
                    {
                        E131Packet.CopySeqNumSlots(uE.PhyBuffer, channelValues, uE.Start, universeSize, uE.seqNum++);
                        uE.Socket.SendTo(uE.PhyBuffer, uE.DestIpEndPoint);
                        uE.EventRepeatCount = _data.EventRepeatCount;

                        uE.PktCount++;
                        uE.SlotCount += uE.Size;
                    }
                }
            }

            stopWatch.Stop();

            this._totalTicks += stopWatch.ElapsedTicks;
        }

		private void LoadSetupNodeInfo()
        {
            if (_data == null)
            {
                _data = new E131ModuleDataModel();
                _data.Universes = new List<UniverseEntry>();
                _data.Warnings = true;
                _data.Statistics = false;
                _data.EventRepeatCount = 0;
            }

            if (_data.Universes == null)
                _data.Universes = new List<UniverseEntry>();

            if (System.IO.File.Exists("Modules\\Controller\\E131settings.xml"))
            {
                ImportOldSettingsFile();
                System.IO.File.Move("Modules\\Controller\\E131settings.xml", "Modules\\Controller\\E131settings.xml.old");
            }

			foreach (var uE in _data.Universes)
			{
				// somehow.. maybe when moving a config from one system to another
				// or when network ids come and go on the same system
				// or if the serializer fails to load these
				// if both of these are zero the Setup will fail leaving
				// this instance in a bad state
				// so make sure at least multicast is non-null
				// Setup will report the error and deactivate this universe
				// At least then we can start up without null ptr exceptions
				if (uE.Unicast == null && uE.Multicast == null)
				{
					//Console.WriteLine("e131 fixing null multicast...");
					uE.Multicast = "null";
				}
					
			}

        }

        private void ImportOldSettingsFile()
        {
            int rowNum = 1;

            //Setup the XML Document

            XmlNode _setupNode;
            XmlDocument doc;

            doc = new XmlDocument();

            doc.Load("Modules\\Controller\\E131settings.xml");

            //Navigate to the correct part of the XML file
            _setupNode = doc.ChildNodes.Item(1);



            foreach (XmlNode child in _setupNode.ChildNodes)
            {
                XmlAttributeCollection attributes = child.Attributes;
                XmlNode attribute;

                if (child.Name == "Options")
                {
                    _data.Warnings = false;
                    if ((attribute = attributes.GetNamedItem("warnings")) != null)
                    {
                        if (attribute.Value == "True")
                        {
                            _data.Warnings = true;
                        }
                    }

                    _data.Statistics = false;
                    if ((attribute = attributes.GetNamedItem("statistics")) != null)
                    {
                        if (attribute.Value == "True")
                        {
                            _data.Statistics = true;
                        }
                    }

                    _data.EventRepeatCount = 0;
                    if ((attribute = attributes.GetNamedItem("eventRepeatCount")) != null)
                    {
                        _data.EventRepeatCount = attribute.Value.TryParseInt32(0);
                    }
                }

                if (child.Name == "Universe")
                {
                    bool active = false;
                    int universe = 1;
                    int start = 1;
                    int size = 1;
                    string unicast = null;
                    string multicast = null;
                    int ttl = 1;

                    if ((attribute = attributes.GetNamedItem("active")) != null)
                    {
                        if (attribute.Value == "True")
                        {
                            active = true;
                        }
                    }

                    if ((attribute = attributes.GetNamedItem("number")) != null)
                    {
                        universe = attribute.Value.TryParseInt32(1);
                    }

                    if ((attribute = attributes.GetNamedItem("start")) != null)
                    {
                        start = attribute.Value.TryParseInt32(1);
                    }

                    if ((attribute = attributes.GetNamedItem("size")) != null)
                    {
                        size = attribute.Value.TryParseInt32(1);
                    }

                    if ((attribute = attributes.GetNamedItem("unicast")) != null)
                    {
                        unicast = attribute.Value;
                    }

                    if ((attribute = attributes.GetNamedItem("multicast")) != null)
                    {
                        multicast = attribute.Value;
                    }

                    if ((attribute = attributes.GetNamedItem("ttl")) != null)
                    {
                        ttl = attribute.Value.TryParseInt32(1);
                    }

                    _data.Universes.Add(
                        new UniverseEntry(rowNum++, active, universe, start - 1, size, unicast, multicast, ttl));
                }
            }


        }
    }
}