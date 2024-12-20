﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http; // HttpClient
using Newtonsoft.Json;
using System.Threading; // JsonConvert

namespace AgendaSQL_App.Model
{
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class _0H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public int TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public int PRMSL { get; set; }
            public int APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _10H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _11H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _12H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _13H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public int APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _14H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public int APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _15H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public int APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _16H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public int APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _17H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public int TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _18H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _19H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _1H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _20H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _21H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _22H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _23H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public int APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _2H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _3H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _4H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _5H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public int APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _6H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public int APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _7H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public int APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _8H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public int TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class _9H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public object WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public int RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public int WNDSPD10m { get; set; }
            public int WNDGUST10m { get; set; }
            public int WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public int ISSNOW { get; set; }
            public string HCDC { get; set; }
            public string MCDC { get; set; }
            public string LCDC { get; set; }
            public int HGT0C { get; set; }
            public int KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public int CIN180_0 { get; set; }
        }

        public class CityInfo
        {
            public string name { get; set; }
            public string country { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string elevation { get; set; }
            public string sunrise { get; set; }
            public string sunset { get; set; }
        }

        public class CurrentCondition
        {
            public string date { get; set; }
            public string hour { get; set; }
            public int tmp { get; set; }
            public int wnd_spd { get; set; }
            public int wnd_gust { get; set; }
            public string wnd_dir { get; set; }
            public double pressure { get; set; }
            public int humidity { get; set; }
            public string condition { get; set; }
            public string condition_key { get; set; }
            public string icon { get; set; }
            public string icon_big { get; set; }
        }

        public class FcstDay0
        {
            public string date { get; set; }
            public string day_short { get; set; }
            public string day_long { get; set; }
            public int tmin { get; set; }
            public int tmax { get; set; }
            public string condition { get; set; }
            public string condition_key { get; set; }
            public string icon { get; set; }
            public string icon_big { get; set; }
            public HourlyData hourly_data { get; set; }
        }

        public class FcstDay1
        {
            public string date { get; set; }
            public string day_short { get; set; }
            public string day_long { get; set; }
            public int tmin { get; set; }
            public int tmax { get; set; }
            public string condition { get; set; }
            public string condition_key { get; set; }
            public string icon { get; set; }
            public string icon_big { get; set; }
            public HourlyData hourly_data { get; set; }
        }

        public class FcstDay2
        {
            public string date { get; set; }
            public string day_short { get; set; }
            public string day_long { get; set; }
            public int tmin { get; set; }
            public int tmax { get; set; }
            public string condition { get; set; }
            public string condition_key { get; set; }
            public string icon { get; set; }
            public string icon_big { get; set; }
            public HourlyData hourly_data { get; set; }
        }

        public class FcstDay3
        {
            public string date { get; set; }
            public string day_short { get; set; }
            public string day_long { get; set; }
            public int tmin { get; set; }
            public int tmax { get; set; }
            public string condition { get; set; }
            public string condition_key { get; set; }
            public string icon { get; set; }
            public string icon_big { get; set; }
            public HourlyData hourly_data { get; set; }
        }

        public class FcstDay4
        {
            public string date { get; set; }
            public string day_short { get; set; }
            public string day_long { get; set; }
            public int tmin { get; set; }
            public int tmax { get; set; }
            public string condition { get; set; }
            public string condition_key { get; set; }
            public string icon { get; set; }
            public string icon_big { get; set; }
            public HourlyData hourly_data { get; set; }
        }

        public class ForecastInfo
        {
            public object latitude { get; set; }
            public object longitude { get; set; }
            public string elevation { get; set; }
        }

        public class HourlyData
        {
            public _0H00 _0H00 { get; set; }
            public _1H00 _1H00 { get; set; }
            public _2H00 _2H00 { get; set; }
            public _3H00 _3H00 { get; set; }
            public _4H00 _4H00 { get; set; }
            public _5H00 _5H00 { get; set; }
            public _6H00 _6H00 { get; set; }
            public _7H00 _7H00 { get; set; }
            public _8H00 _8H00 { get; set; }
            public _9H00 _9H00 { get; set; }
            public _10H00 _10H00 { get; set; }
            public _11H00 _11H00 { get; set; }
            public _12H00 _12H00 { get; set; }
            public _13H00 _13H00 { get; set; }
            public _14H00 _14H00 { get; set; }
            public _15H00 _15H00 { get; set; }
            public _16H00 _16H00 { get; set; }
            public _17H00 _17H00 { get; set; }
            public _18H00 _18H00 { get; set; }
            public _19H00 _19H00 { get; set; }
            public _20H00 _20H00 { get; set; }
            public _21H00 _21H00 { get; set; }
            public _22H00 _22H00 { get; set; }
            public _23H00 _23H00 { get; set; }
        }

        public class Root
        {
            public CityInfo city_info { get; set; }
            public ForecastInfo forecast_info { get; set; }
            public CurrentCondition current_condition { get; set; }
            public FcstDay0 fcst_day_0 { get; set; }
            public FcstDay1 fcst_day_1 { get; set; }
            public FcstDay2 fcst_day_2 { get; set; }
            public FcstDay3 fcst_day_3 { get; set; }
            public FcstDay4 fcst_day_4 { get; set; }
        }
    }

