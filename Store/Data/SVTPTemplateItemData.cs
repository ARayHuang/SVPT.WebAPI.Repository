using SVPT.WebAPI.Store.Context;
using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Store.Data
{
    public class SVTPTemplateItemData : IBulkData<SVTPTemplateItem>
    {
        private SVTPDbContext _svtpDbContext;

        public SVTPTemplateItemData(SVTPDbContext context)
        {
            this._svtpDbContext = context;
        }

        public void InsertBulkData()
        {
            List<SVTPTemplateItem> data = GenerateData();
            this._svtpDbContext.tblSVTPTemplateItem.AddRange(data);
        }

        private List<string> GenerateDummyFileName() 
        {
            List<string> fileNames = new List<string>();

            fileNames.Add("AC01 - System Acoustic Noise Results");
            fileNames.Add("AC02 - Electrical PCA Acoustic Results");
            fileNames.Add("AC03 - Display Hinge-Up Acoustic Results");
            fileNames.Add("AC04 - Click Pad Acoustic Results");
            fileNames.Add("CCD01 - Cosmetic Taber & RCA Life Results");
            fileNames.Add("CCD02 - Cosmetic Edge Results");
            fileNames.Add("CCD03 - Cosmetic Printed Icon Abrasion Results");
            fileNames.Add("CCD04 - Cosmetic Healthcare Chemical Cleaning Results");
            fileNames.Add("CCD05 - Cosmetic Easyclean Chemical Cleaning Results");
            fileNames.Add("CCI01 - Cosmetic Inspection Results");
            fileNames.Add("CCI02 - Cosmetic Stain and Fade Results");
            fileNames.Add("CCI03 - Cosmetic Adhesive Clad Verification Results");
            fileNames.Add("CCI04 - Cosmetic Tackiness Results");
            fileNames.Add("CCI05 - Cosmetic Scratch & Sweat Results");
            fileNames.Add("CCM01 - Cosmetic Color Spectrophotometer Results");
            fileNames.Add("CCM02 - Cosmetic Thickness Measurement Results");
            fileNames.Add("CCS01 - Cosmetic Cross-Cut Results");
            fileNames.Add("CCS02 - Cosmetic Clad Wedge Peel Results");
            fileNames.Add("CCS03 - Cosmetic Adhesive Clad Bonding Durability Results");
            fileNames.Add("CCS04 - Cosmetic Pencil Hardness Results");
            fileNames.Add("CCS05 - Cosmetic Boiling Results");
            fileNames.Add("CCS06 - Cosmetic Steel Wool Abrasion Results");
            fileNames.Add("CCS07 - Cosmetic Environmental Accelerated Life Results");
            fileNames.Add("CCS08 - Cosmetic Thermal Shock Results");
            fileNames.Add("CCS09 - Cosmetic Salt Fog Results");
            fileNames.Add("CF01 - WLAN Function & LED  Results");
            fileNames.Add("CF02 - WWAN Functional Results");
            fileNames.Add("CF03 - WWAN BIOS Behavior Results");
            fileNames.Add("CM01 - Intel_Pulsar_CNVio_Schematic_Layout - checklist");
            fileNames.Add("CM01 - Intel_Quasar_CNVio_Schematic_Layout- checklist");
            fileNames.Add("CM01 - Radio Modules Integration Design Check");
            fileNames.Add("CM02 - Wireless M.2 Card Ground Results");
            fileNames.Add("CM03 - Wireless Antenna Performance - Active Antenna Results");
            fileNames.Add("CM03 - Wireless Antenna Performance Results");
            fileNames.Add("CM04 - SIM Signal Integrity & SIM RSP Results");
            fileNames.Add("CM05 - WLAN Performance Results_Module Name");
            fileNames.Add("CM06 - WLAN Conductive Performance Results");
            fileNames.Add("CM07 - WLAN COB RF_Parameter and Conductive Performance Results");
            fileNames.Add("CM08 - WLAN Radio Interference_Commodity Matrix");
            fileNames.Add("CM08 - WLAN Radio Interference");
            fileNames.Add("CM09 - Embedded Bluetooth Module Results");
            fileNames.Add("CM10 - WLAN_BT Combo Performance Results");
            fileNames.Add("CM11 - WWAN Performance Results");
            fileNames.Add("CM12 - WWAN COB Conducted RF Results");
            fileNames.Add("CM13 - WWAN Radio Interference_Commodity Matrix");
            fileNames.Add("CM13 - WWAN Radio Interference");
            fileNames.Add("CM14 - WWAN SAR Power Test Results");
            fileNames.Add("CM15 - GPS Receiver Interference Results_v3.0");
            fileNames.Add("CM16 - GPS Performance Results_v3.0");
            fileNames.Add("CM17 - NFC & RFID Performance Results");
            fileNames.Add("CM18 - WirelessHD Performance Results");
            fileNames.Add("CM19 - UHF RFID Tag Performance Results");
            fileNames.Add("CM20 - Wigig Parameter Results");
            fileNames.Add("CM21 - Wigig Performance Results");
            fileNames.Add("CM22 - Wigig Noise Results");
            fileNames.Add("CM23 - Ethernet Checklist - Rev J");
            fileNames.Add("CM24 - NFC TAG Performance Results");
            fileNames.Add("CM25 - WLAN BIOS Related Setting Verification");
            fileNames.Add("CM26 - WWAN WIFI C-SAR Results and Co-SAR Evaluative");
            fileNames.Add("CM27 - WIFI Module RF Power Measurement_Results");
            fileNames.Add("CM28 - IoT BLE Descrete Tile 1.0 Module Performance Results");
            fileNames.Add("CM28 - IoT Integration InTile Module Performance Results");
            fileNames.Add("ED01 - System Restart Cycling Results");
            fileNames.Add("ED02 - System Standby Cycling Results");
            fileNames.Add("ED03 - System Hibernate Cycling Results");
            fileNames.Add("ED04 - In-Rush power Current Results");
            fileNames.Add("ED05 - LED Backlight In-Rush Current Results");
            fileNames.Add("ED06 - Speaker Reliability Results");
            fileNames.Add("EF01 - Basic Functional-System Test");
            fileNames.Add("EF02 - ECC Test");
            fileNames.Add("EF03 - Camera Test Results");
            fileNames.Add("EF04 - ALS Results");
            fileNames.Add("EF05 - Sensor Hub Results");
            fileNames.Add("EF06 - Device Mode Detection Results");
            fileNames.Add("EF07 - Touch Digitizer Results");
            fileNames.Add("EF08 - Pen Digitizer Results");
            fileNames.Add("EF09 - No Battery AC Adapter Test");
            fileNames.Add("EF10 - Overnight Charge Verification Results");
            fileNames.Add("EF11 - Battery Pack Shipping Mode Verification Results");
            fileNames.Add("EF12 - Touch, Click Pad in System");
            fileNames.Add("EF13 - Click Pad Performance with NFC Interference");
            fileNames.Add("EM01 - Layout Review Results");
            fileNames.Add("EM02 - PCBA Test Points Coverage For Manufacture Result");
            fileNames.Add("EM03 - RTC Accuracy Results");
            fileNames.Add("EM04 - RTC Power Consumption Results");
            fileNames.Add("EM05 - Power Sequencing");
            fileNames.Add("EM07 - Panel Power Sequence");
            fileNames.Add("EM08 - Vref Voltage Results");
            fileNames.Add("EM09 - DC Voltage Margin Results");
            fileNames.Add("EM10 - CPU Transient Voltage at Margin");
            fileNames.Add("EM11 - Processor Throttling Results");
            fileNames.Add("EM12 - CPU Catastrophic Thermal Protection");
            fileNames.Add("EM13 - Port Loadings Measurement Results");
            fileNames.Add("EM14 - Power Routing Load Results");
            fileNames.Add("EM15 - Power Rail Leakage");
            fileNames.Add("EM16 - Power Rails - Transient States");
            fileNames.Add("EM17 - Power Rails - Steady State");
            fileNames.Add("EM18 - DC-DC Converter Signal Integrity");
            fileNames.Add("EM19 - Voltage Regulators Efficiency Test");
            fileNames.Add("EM20 - OCP of Power through the Cable Test Results");
            fileNames.Add("EM21 - Battery Life Results");
            fileNames.Add("EM22 - S3 Standby Battery Life Results");
            fileNames.Add("EM23 - S4 S5 Battery Life Results");
            fileNames.Add("EM25 - Audio Ground Isolation Verification");
            fileNames.Add("EM26 - System Performance Benchmarks");
            fileNames.Add("EM27 - HDD Speaker Results");
            fileNames.Add("EM28^1 - C-Link Signal Integrity");
            fileNames.Add("EM28^2 -Clock Generator Signal Integrity ");
            fileNames.Add("EM28^3 - DMI Signal Integrated");
            fileNames.Add("EM28^4 -DMIC Signal Integrity");
            fileNames.Add("EM28^5 -EMMC Signal Integrity");
            fileNames.Add("EM28^6 - eSPI signal integrity");
            fileNames.Add("EM28^7 -I2C bus  SMbus signal integrity");
            fileNames.Add("EM28^8 - I2C bus & SMbus signal integrity");
            fileNames.Add("EM28^9 -LPC Signal Integrity");
            fileNames.Add("EM28^10 -Memory Signal Integrity");
            fileNames.Add("EM28^11- MIPI Signal Integrity");
            fileNames.Add("EM28^12 -NIC signal integrity");
            fileNames.Add("EM28^13-PCIe(Device) Signal Integrated");
            fileNames.Add("EM28^14-SDXC Card Signal Integrity");
            fileNames.Add("EM28^15-Smart card signal integrity");
            fileNames.Add("EM28^16-SPI_Signal Integrity");
            fileNames.Add("EM28^17- SVID Signal Integrity");
            fileNames.Add("EM28^18-TBT Signal Integrity");
            fileNames.Add("EM28^19-USB Signal Integrity (Device)");
            fileNames.Add("EM28^20-USB Signal Integrity (External port)");
            fileNames.Add("EM29 - USB Type C Results");
            fileNames.Add("EM30 - SATA Signal Integrity");
            fileNames.Add("EM31 - SATA Gen3 Margin Results");
            fileNames.Add("EM32 - Display Port Results");
            fileNames.Add("EM33 - Embedded Display Port Results");
            fileNames.Add("EM34 - HDMI Port Results");
            fileNames.Add("EM36 - Residual Voltage");
            fileNames.Add("EM37 - Acoustic System Rattling Results");
            fileNames.Add("EM38 - Headphone Output Results");
            fileNames.Add("EM39 - Noise Level in Headphone Output Results");
            fileNames.Add("EM40 - Speaker Amplifer Power Output");
            fileNames.Add("EM41 - Discrete Speaker Amp Power on Sequence");
            fileNames.Add("EM42 - Acoustic Microphone Sealing Result");
            fileNames.Add("EM43 - Acoustic Speaker Sealing Result");
            fileNames.Add("EM44 - Acoustic Microphone Array Results");
            fileNames.Add("EM45 - Speaker Phase Test Results");
            fileNames.Add("EM46 - Display Performance Results");
            fileNames.Add("EM47 - Panel Brightness Table");
            fileNames.Add("EM48 - Panel Power Consumption Results");
            fileNames.Add("EM49 - System Battery Charger Results");
            fileNames.Add("EM50 - Current Draw - Battery");
            fileNames.Add("EM51 - Battery Fast Charge Verification");
            fileNames.Add("EM52 - Smart Adapter Functional Results");
            fileNames.Add("EM53 - Current Draw - Smart Adapter");
            fileNames.Add("EM54 - Supplemental Power Verification Results");
            fileNames.Add("EM55 - Mouse Pad Grounding Results");
            fileNames.Add("EM56 - Touch Screen Grounding Results");
            fileNames.Add("EM57 - System Display Luminance Uniformity Results");
            fileNames.Add("EN01 - Extreme Environment Operational  Results");
            fileNames.Add("EN02 - Storage - Temperature & Humidity Results");
            fileNames.Add("EN03 - Storage - Low Temperature Results");
            fileNames.Add("EN04 - Mouse Pad Conducted Susceptibility Results");
            fileNames.Add("EN05 - Sand And Dust Ingest Results");
            fileNames.Add("EN05 - Sand And Dust Ingest Results");
            fileNames.Add("EN06 - Water Ingress Results");
            fileNames.Add("EN07 - Fibrous Dust Results");
            fileNames.Add("EN08 - Healthcare - Chemical Resistant - Wipes");
            fileNames.Add("EN09 - Healthcare - Chemical Resistant - Nuvan ProStrips");
            fileNames.Add("EN10 - High Humidity Results");
            fileNames.Add("EN11 - HP Logo Adhesion Test Results");
            fileNames.Add("EN11 - HP Logo Environmrntal Test Results");
            fileNames.Add("EN12 - Easyclean - Chemical Resistant - Wipes");
            fileNames.Add("ES01 - Loaded Power Supply Results");
            fileNames.Add("ES02 - Memory Module Stress Results");
            fileNames.Add("ES03 - AMD Memory Module Margin Results");
            fileNames.Add("ES03 - Intel Memory Module Margin Results");
            fileNames.Add("ES04 - Port Short Results");
            fileNames.Add("ES05 - C-Link Stress Results");
            fileNames.Add("ES06 - Graphics Vendor Specific Results");
            fileNames.Add("ES07 - Video Memory Results");
            fileNames.Add("ES08 - Type-C Port OVP Verification Results");
            fileNames.Add("MD01 - Bench Top Drop Results");
            fileNames.Add("MD02 - Static Load Results");
            fileNames.Add("MD03 - IO Connector Life Results");
            fileNames.Add("MD04 - Button-Switch Life Results");
            fileNames.Add("MD05 - Device, Latch and Connector Life Results");
            fileNames.Add("MD06 - Click Pad Life Results");
            fileNames.Add("MD06 - Pick Button Life Results");
            fileNames.Add("MD07 - Hinge Life Results");
            fileNames.Add("MD08 - Keyboard Life Results");
            fileNames.Add("MD09 - Base Enclosure Anti-Skid Foot Results");
            fileNames.Add("MD10 - FPC in soft keyboard Results");
            fileNames.Add("MD11 - Logos, Badges, Labels and Laser Etched Barcode Abrasion Results");
            fileNames.Add("MD12 - Keycaps - Legend Abrasion");
            fileNames.Add("MD13 - Painted Keycaps - Texture Durability");
            fileNames.Add("MD14 - Touchpad Surface Abrasion");
            fileNames.Add("MD15 - Camera Privacy Slider Life Result");
            fileNames.Add("MD16 - Pen Draw Life Results");
            fileNames.Add("MI01 - Open Box Inspection Results");
            fileNames.Add("MI02 - Dye Stain Results");
            fileNames.Add("MI03 - Cursor Movement during Keyboard Flex Results");
            fileNames.Add("MI04 - Disassembly-Assembly Results");
            fileNames.Add("MI05 - Coffee-Soda-Water Results");
            fileNames.Add("MI06 - All-In-One Flash Interface Results");
            fileNames.Add("MI07 - Active HDD Protection Results");
            fileNames.Add("MI08 - Based & Display Enclosure Operational Flexural Resistance Results");
            fileNames.Add("MM01 - System Weight Matrix");
            fileNames.Add("MM02 - Keyboard Deflection Results");
            fileNames.Add("MM03 - Magnetic Field Strengths");
            fileNames.Add("MM04 - Palm Rest Vibration Results");
            fileNames.Add("MM05 - Tip Over Results");
            fileNames.Add("MM06 - Open LCD With Single Hand Results");
            fileNames.Add("MM07 - LCD Wobble Results");
            fileNames.Add("MM08 - LCD Cover Fall Down During Vibration Results");
            fileNames.Add("MM09 - Connector Key Parameters Measurement Results");
            fileNames.Add("MM10 - Strain Gauge - PCA Fixtures");
            fileNames.Add("MM11 - Strain Gauge - In-Form Factor");
            fileNames.Add("MM12 - Strain Gauge - System Shock");
            fileNames.Add("MM13 - X360 Panel Adhesion Results");
            fileNames.Add("MM14 - Camera Privacy Slider Pull Force Results");
            fileNames.Add("MM15 - Magnetic Pen Attachment Force Results");
            fileNames.Add("MS01 - System Vibration Results");
            fileNames.Add("MS02 - Package Vibration Results");
            fileNames.Add("MS03 - System Shock Results");
            fileNames.Add("MS04 - System Low Level Drop Results");
            fileNames.Add("MS05 - Tumble Results");
            fileNames.Add("MS06 - Package Drop Results");
            fileNames.Add("MS07 - Device Torque Results");
            fileNames.Add("MS08 - Bending Test Results");
            fileNames.Add("MS09 - Enclosure Force Withstanding Results");
            fileNames.Add("MS10 - Display Enclosure Compression Results");
            fileNames.Add("MS11 - Panel Scuff Results");
            fileNames.Add("MS12 - Hinge UP Overload Push Results");
            fileNames.Add("MS13 - Glass Cover Impact Results");
            fileNames.Add("MS14 - IO Connector with plug Drop Results");
            fileNames.Add("MS15 - Button-Switch Stress Results");
            fileNames.Add("MS16 - Device, Latch and Connector Overload Results");
            fileNames.Add("MS17 - Click Pad Overload Results");
            fileNames.Add("MS17 - Pick Button Overload Results");
            fileNames.Add("MS18 - HDD Transmissibility Results");
            fileNames.Add("MS19 - Security Lock Overload Results");
            fileNames.Add("MS20 - Internal MB Connector Results");
            fileNames.Add("MS21 - Touch Panel Cover Glass Hardness Results");
            fileNames.Add("MS23 - Yank Test Results");
            fileNames.Add("MS24 - USB-C Wiggile Results");
            fileNames.Add("MS25 - Battery Drop Results");
            fileNames.Add("MS26 - X360 LCD and Cover Adhesion Results");
            fileNames.Add("MS27 - Pen Tether and Pen Loop Strength Results");
            fileNames.Add("RC01 - ESD Results");
            fileNames.Add("RC02 - External Battery Pack ESD Results");
            fileNames.Add("RC03 - Touch Voltage Results");
            fileNames.Add("RC04 - RF Immunity Results");
            fileNames.Add("RC05 - Mobile Phone and Internal WWAN Interference Results");
            fileNames.Add("RC06 - Radiated Emssions Results");
            fileNames.Add("RC07 - eStar Certification");
            fileNames.Add("RC08 - Sharp Edge Results");
            fileNames.Add("TH01 - Thermal Test Results");
            fileNames.Add("TH02 - Thermal Solution Functional Verification");
            fileNames.Add("TH03 - Battery Thermal Environment Results");
            fileNames.Add("TH04 - Thermal Module Clamp Pressure Results");
            fileNames.Add("TH05 - Heatpipe Orientation Thermal Results");
            fileNames.Add("TH06 - Thermal Fan Start (90B) Results");
            fileNames.Add("TH07 - Fan Test Results");

            return fileNames;

        }
        
        public List<SVTPTemplateItem> GenerateData()
        {
            List<SVTPTemplateItem> bulkData = new List<SVTPTemplateItem>();
            List<string> fileNames = this.GenerateDummyFileName();

            foreach (var fileName in fileNames) 
            {
                string[] key = fileName.Split("-");

                var item = key[0].Contains('^') ? key[0].Split('^')[0].Trim() : key[0];
                var subItem = key[0].Contains('^') ? key[0].Split('^')[1].Trim() : string.Empty;
                var information = String.Join("-", key, 1, key.Length - 1).Trim();

                bulkData.Add(new SVTPTemplateItem
                {
                    Id = new Guid(),
                    SVTPTemplateId = Guid.Parse("18691110-5CDF-45A2-B258-6699DAE71BD2"),
                    Item = item,
                    SubItem = subItem,
                    Information = information,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
            }

            return bulkData;
        }
    }
}
