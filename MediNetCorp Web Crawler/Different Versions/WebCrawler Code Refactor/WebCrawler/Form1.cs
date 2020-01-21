using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Resources;
using System.IO;
using System.Text.RegularExpressions;

namespace WebCrawler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();   
            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
           
        }

        private void btngraburl_Click(object sender, EventArgs e)
        {
            string baseuri = "";
  
            if (cmbjob.Text == "All Jobs")
            {
                string[] arr = new string[] { "Accounting + Finance","Admin + Office","Arch + Engineering","Art + Media + Design","Biotech + Science","Business + Management","Customer Service","Education","Food + Bev + Hosp","General Labor","Government","Human Resources","Internet Engineers","Legal + Paralegal","Manufacturing","Marketing + Pr + Ad","Nonprofit Sector","Real Estate","Retail + Wholesale","Sales + Biz Dev","Salon + Spa + Fitness","Security","Skilled Trade + Craft","Software + Ga + Dba","Systems + Network","Technical Support","Transport","Tv + Film + Video","Web + Info Design","Writing + Editing","[ETC]","[Part-Time]" };
                foreach (string s in arr)
                {
                    if (s == "Accounting + Finance")
                    {
                        baseuri = ".craigslist.org/search/acc?query=";
                    }
                    else if (s == "Admin + Office")
                    {
                        baseuri = ".craigslist.org/search/ofc?query=";
                    }
                    else if (s== "Arch + Engineering")
                    {
                        baseuri = ".craigslist.org/search/egr?query=";
                    }
                    else if (s == "Art + Media + Design")
                    {
                        baseuri = ".craigslist.org/search/med?query=";
                    }
                    else if (s == "Biotech + Science")
                    {
                        baseuri = ".craigslist.org/search/sci?query=";
                    }
                    else if (s == "Business + Management")
                    {
                        baseuri = ".craigslist.org/search/bus?query=";
                    }
                    else if (s == "Customer Service")
                    {
                        baseuri = ".craigslist.org/search/csr?query=";
                    }
                    else if (s == "Education")
                    {
                        baseuri = ".craigslist.org/search/edu?query=";
                    }
                    else if (s == "Food + Bev + Hosp")
                    {
                        baseuri = ".craigslist.org/search/fbh?query=";
                    }
                    else if (s == "General Labor")
                    {
                        baseuri = ".craigslist.org/search/lab?query=";
                    }
                    else if (s == "Government")
                    {
                        baseuri = ".craigslist.org/search/gov?query=";
                    }
                    else if (s == "Human Resources")
                    {
                        baseuri = ".craigslist.org/search/hum?query=";
                    }
                    else if (s == "Internet Engineers")
                    {
                        baseuri = ".craigslist.org/search/eng?query=";
                    }
                    else if (s == "Legal + Paralegal")
                    {
                        baseuri = ".craigslist.org/search/lgl?query=";
                    }
                    else if (s == "Manufacturing")
                    {
                        baseuri = ".craigslist.org/search/mnu?query=";
                    }
                    else if (s == "Marketing + Pr + Ad")
                    {
                        baseuri = ".craigslist.org/search/mar?query=";
                    }                   
                    else if (s == "Nonprofit Sector")
                    {
                        baseuri = ".craigslist.org/search/npo?query=";
                    }
                    else if (s == "Real Estate")
                    {
                        baseuri = ".craigslist.org/search/rej?query=";
                    }
                    else if (s == "Retail + Wholesale")
                    {
                        baseuri = ".craigslist.org/search/ret?query=";
                    }
                    else if (s== "Sales + Biz Dev")
                    {
                        baseuri = ".craigslist.org/search/sls?query=";
                    }
                    else if (s == "Salon + Spa + Fitness")
                    {
                        baseuri = ".craigslist.org/search/spa?query=";
                    }
                    else if (s== "Security")
                    {
                        baseuri = ".craigslist.org/search/sec?query=";
                    }
                    else if (s == "Skilled Trade + Craft")
                    {
                        baseuri = ".craigslist.org/search/trd?query=";
                    }
                    else if (s == "Software + Ga + Dba")
                    {
                        baseuri = ".craigslist.org/search/sof?query=";
                    }
                    else if (s == "Systems + Network")
                    {
                        baseuri = ".craigslist.org/search/sad?query=";
                    }
                    else if (s == "Technical Support")
                    {
                        baseuri = ".craigslist.org/search/tch?query=";
                    }
                    else if (s == "Transport")
                    {
                        baseuri = ".craigslist.org/search/trp?query=";
                    }
                    else if (s == "Tv + Film + Video")
                    {
                        baseuri = ".craigslist.org/search/tfr?query=";
                    }
                    else if (s == "Web + Info Design")
                    {
                        baseuri = ".craigslist.org/search/web?query=";
                    }
                    else if (s == "Writing + Editing")
                    {
                        baseuri = ".craigslist.org/search/wri?query=";
                    }
                    else if (s == "[ETC]")
                    {
                        baseuri = ".craigslist.org/search/etc?query=";
                    }
                    else if (s == "[Part-Time]")
                    {
                        baseuri = ".craigslist.org/search/jjj?is_parttime=1&query=";
                    }
                }
            }
            else if (cmbjob.Text == "Medical + Health")
            {
                baseuri = ".craigslist.org/search/hea?query=";
            }          
            try
            {
                if (cmbstate.Text=="" || txtkeyword.Text == "" || cmbjob.Text=="")
                {
                    MessageBox.Show("Select or Enter Proper Values");
                    return;
                }
                else
                {
                    txtkeyword.Text += " " + txtkeyword2.Text;
                    if (cmbstate.Text == "Alabama")
                        {
                        
                             string[] arr =  new string[]{ "auburn", "birmingham", "dothan", "florence / muscle shoals", "gadsden-anniston", "huntsville / decatur", "mobile", "montgomery", "tuscaloosa" };
                             progressBar.Visible = true;
                             progressBar.Minimum = 0;
                             progressBar.Maximum = arr.Length;
                             progressBar.Value = 1;
                             progressBar.Step = 1;

                             foreach (string s in arr)
                             {
                                 if (s == "auburn")
                                 {
                                     string additionalurl = "http://" + s + ".craigslist.org";
                                     
                                     string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                     MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                     if (progressBar.Value != progressBar.Maximum)
                                     {
                                         progressBar.PerformStep();
                                     }
                                 }
                                 else if (s == "dothan")
                                 {
                                     string additionalurl = "http://" + s + ".craigslist.org";
                                    
                                     string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                     MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                     if (progressBar.Value != progressBar.Maximum)
                                     {
                                         progressBar.PerformStep();
                                     }
                                   
                                 }
                                 else if (s == "birmingham")
                                 {
                                     string rv= s.Replace("birmingham", "bham");

                                     string additionalurl = "http://" + rv + ".craigslist.org";
                                    
                                     string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                     MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                     if (progressBar.Value != progressBar.Maximum)
                                     {
                                         progressBar.PerformStep();
                                     }
                                 }
                                 else if (s == "florence / muscle shoals")
                                 {
                                     string rv = s.Replace("florence / muscle shoals", "shoals");

                                     string additionalurl = "http://" + rv + ".craigslist.org";
                                    
                                     string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                     MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                     if (progressBar.Value != progressBar.Maximum)
                                     {
                                         progressBar.PerformStep();
                                     }
                                 }
                                 else if (s == "gadsden-anniston")
                                 {
                                     string rv = s.Replace("gadsden-anniston", "gadsden");

                                     string additionalurl = "http://" + rv + ".craigslist.org";
                                    
                                     string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                     MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                     if (progressBar.Value != progressBar.Maximum)
                                     {
                                         progressBar.PerformStep();
                                     }
                                 }
                                 else if (s == "huntsville / decatur")
                                 {
                                     string rv = s.Replace("huntsville / decatur", "huntsville");

                                     string additionalurl = "http://" + rv + ".craigslist.org";
                                                                  
                                     string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                     MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                    
                                 }
                                 else if (s == "mobile")
                                 {
                                     string additionalurl = "http://" + s + ".craigslist.org";
                                    
                                     string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                     MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                     if (progressBar.Value != progressBar.Maximum)
                                     {
                                         progressBar.PerformStep();
                                     }
                                 }
                                 else if (s == "montgomery")
                                 {
                                     string additionalurl = "http://" + s + ".craigslist.org";
                                    
                                     string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                     MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                     if (progressBar.Value != progressBar.Maximum)
                                     {
                                         progressBar.PerformStep();
                                     }
                                 }
                                 else if (s == "tuscaloosa")
                                 {
                                     string additionalurl = "http://" + s + ".craigslist.org";
                                    
                                     string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                     MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                     if (progressBar.Value != progressBar.Maximum)
                                     {
                                         progressBar.PerformStep();
                                     }
                                 }
                               
                             }
                                 
                    }
                      else if (cmbstate.Text == "Alaska")
                          {
                            string[] arr = { "anchorage / mat-su", "fairbanks", "kenai peninsula", "southeast alaska"};
                            progressBar.Visible = true;
                            progressBar.Minimum = 0;
                            progressBar.Maximum = arr.Length;
                            progressBar.Value = 1;
                            progressBar.Step = 1;
                          foreach (string s in arr)
                            {
                                if (s == "anchorage / mat-su")
                                {
                                    string rv = s.Replace("anchorage / mat-su", "anchorage");

                                    string additionalurl = "http://" + rv + ".craigslist.org";
                                   
                                    string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                    MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                    if (progressBar.Value != progressBar.Maximum)
                                    {
                                        progressBar.PerformStep();
                                    }
                                }
                                else if (s == "fairbanks")
                                {
                                    string additionalurl = "http://" + s + ".craigslist.org";
                                    
                                    string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                    MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                    if (progressBar.Value != progressBar.Maximum)
                                    {
                                        progressBar.PerformStep();
                                    }
                                }
                                else if (s == "kenai peninsula")
                                {
                                    string rv = s.Replace("kenai peninsula", "kenai");

                                    string additionalurl = "http://" + rv + ".craigslist.org";
                                    
                                    string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                    MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                    if (progressBar.Value != progressBar.Maximum)
                                    {
                                        progressBar.PerformStep();
                                    }
                                }
                                else if (s == "southeast alaska")
                                {
                                    string rv = s.Replace("southeast alaska", "juneau");

                                    string additionalurl = "http://" + rv + ".craigslist.org";
                                   
                                    string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                    MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                    if (progressBar.Value != progressBar.Maximum)
                                    {
                                        progressBar.PerformStep();
                                    }
                                }

                            }
                       }
                    else if (cmbstate.Text == "Arizona")
                    {
                        string[] arr = {"flagstaff / sedona","mohave county","phoenix","prescott","show low","sierra vista","tucson","yuma"};
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "flagstaff / sedon")
                            {
                                string rv = s.Replace("flagstaff / sedon", "flagstaff");                                
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                              
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "mohave county")
                            {
                                string rv = s.Replace("mohave county", "mohave");                               
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;                            
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "phoenix")
                            {                           
                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";
                            
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                                    
                            }
                            else if (s == "prescott")  
                            {                               
                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                               
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "show low")
                            {
                                string rv = s.Replace("show low", "showlow");                               
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";
                               
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "sierra vista")
                            {
                                string rv = s.Replace("sierra vista", "sierravista");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                                            
                                string additionalurl = "http://" + rv + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "tucson")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";
                               
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "yuma")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Arkansas")
                    {
                        string[] arr = { "fayetteville","fort smith","jonesboro","little rock","texarkana" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "fayetteville")
                            {
                                string rv = s.Replace("fayetteville", "fayar");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                               
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "fort smith")
                            {
                                string rv = s.Replace("fort smith", "fortsmith");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                               
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "jonesboro")
                            {               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                               
                                string additionalurl = "http://" + s + ".craigslist.org";
                               
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "little rock")
                            {
                                string rv = s.Replace("little rock", "littlerock");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "texarkana")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "California")
                    {
                        string[] arr = { "bakersfield","chico","fresno / madera","gold country","hanford-corcoran","humboldt county","imperial county","inland empire","los angeles","mendocino county","merced","modesto","monterey bay","orange county","palm springs","redding","sacramento","san diego","san francisco bay area","san luis obispo","santa barbara","santa maria","siskiyou county","stockton","susanville","ventura county","visalia-tulare","yuba-sutter" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "bakersfield")
                            {  
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "chico")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                               
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "fresno / madera")
                            {
                                string rv = s.Replace("fresno / madera", "fresno");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                                                
                                string additionalurl = "http://" + rv + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "gold country")
                            {
                                string rv = s.Replace("gold country", "goldcountry");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "hanford-corcoran")
                            {
                                string rv = s.Replace("hanford-corcoran", "hanford");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "humboldt county")
                            {
                                string rv = s.Replace("humboldt county", "humboldt");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "imperial county")
                            {
                                string rv = s.Replace("imperial county", "imperial");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "inland empire")
                            {
                                string rv = s.Replace("inland empire", "inlandempire");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                              
                                string additionalurl = "http://" + rv + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "los angeles")
                            {
                                string rv = s.Replace("los angeles", "losangeles");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                                                
                                string additionalurl = "http://" + rv + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "mendocino county")
                            {
                                string rv = s.Replace("mendocino county", "mendocino");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                               
                                string additionalurl = "http://" + rv + ".craigslist.org";
                               
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "merced")
                            {                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";
                               
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "modesto")
                            {                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "monterey bay")
                            {
                                string rv = s.Replace("monterey bay", "monterey");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "orange county")
                            {
                                string rv = s.Replace("orange county", "orangecounty");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "palm springs")
                            {
                                string rv = s.Replace("palm springs", "palmsprings");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";
                               
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "redding")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "sacramento")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "san diego")
                            {
                                string rv = s.Replace("san diego", "sandiego");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                               
                                string additionalurl = "http://" + rv + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "san francisco bay area")
                            {
                                string rv = s.Replace("san francisco bay area", "sfbay");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";
                                
                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "san luis obispo")
                            {
                                string rv = s.Replace("san luis obispo", "slo");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "santa barbara")
                            {
                                string rv = s.Replace("santa barbara", "santabarbara");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "santa maria")
                            {
                                string rv = s.Replace("santa maria", "santamaria");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "siskiyou county")
                            {
                                string rv = s.Replace("siskiyou county", "siskiyou");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "stockton")
                            {
                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "susanville")
                            {                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "ventura county")
                            {
                                string rv = s.Replace("ventura county", "ventura");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "visalia-tulare")
                            {
                                string rv = s.Replace("visalia-tulare", "visalia");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "yuba-sutter")
                            {
                                string rv = s.Replace("yuba-sutter", "yubasutter");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                               
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Colorado")
                    {
                        string[] arr = { "boulder","colorado springs","denver","eastern CO","fort collins / north CO","high rockies","pueblo","western slope" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "boulder")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "colorado springs")
                            {
                                string rv = s.Replace("colorado springs", "cosprings");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "denver")
                            {                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "eastern CO")
                            {
                                string rv = s.Replace("eastern CO", "eastco");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "fort collins / north CO")
                            {
                                string rv = s.Replace("fort collins / north CO", "fortcollins");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "high rockies")
                            {
                                string rv = s.Replace("high rockies", "rockies");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "pueblo")
                            {                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "western slope")
                            {
                                string rv = s.Replace("western slope", "westslope");
                              
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Connecticut")
                    {
                        string[] arr = { "eastern CT","hartford","new haven","northwest CT" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "eastern CT")
                            {
                                string rv = s.Replace("eastern CT", "newlondon");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "hartford")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "new haven")
                            {
                                string rv = s.Replace("new haven", "newhaven");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "northwest CT")
                            {
                                string rv = s.Replace("northwest CT", "nwct");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Delaware")
                    {
                        string[] arr = { "delaware" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "delaware")
                            {                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "District of Columbia")
                    {
                        string[] arr = { "washington" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "washington")
                            {
                                string rv = s.Replace("washington", "washingtondc");
                             
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                               
                            }
                        }
                    }
                    else if (cmbstate.Text == "Florida")
                    {
                        string[] arr = { "broward county","daytona beach","florida keys","fort lauderdale","ft myers / SW florida","gainesville","heartland florida","jacksonville","lakeland","miami / dade","north central FL","ocala","okaloosa / walton","orlando","panama city","pensacola","sarasota-bradenton","south florida","space coast","st augustine","tallahassee","tampa bay area","treasure coast","palm beach county" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "broward county")
                            {
                                string rv = s.Replace("broward county", "miami");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                               
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "daytona beach")
                            {
                                string rv = s.Replace("daytona beach", "daytona");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "florida keys")
                            {
                                string rv = s.Replace("florida keys", "keys");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "fort lauderdale")
                            {
                                string rv = s.Replace("fort lauderdale", "miami");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "ft myers / SW florida")
                            {
                                string rv = s.Replace("ft myers / SW florida", "fortmyers");

                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "gainesville")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "heartland florida")
                            {
                                string rv = s.Replace("heartland florida", "cfl");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "jacksonville")
                            {                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lakeland")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "miami / dade")
                            {
                                string rv = s.Replace("miami / dade", "miami");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "north central FL")
                            {
                                string rv = s.Replace("north central FL", "lakecity");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "ocala")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                               
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "okaloosa / walton")
                            {
                                string rv = s.Replace("okaloosa / walton", "okaloosa");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "orlando")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "panama city")
                            {
                                string rv = s.Replace("panama city", "panamacity");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "pensacola")
                            {                              
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "sarasota-bradenton")
                            {
                                string rv = s.Replace("sarasota-bradenton", "sarasota");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "space coast")
                            {
                                string rv = s.Replace("space coast", "spacecoast");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "st augustine")
                            {
                                string rv = s.Replace("st augustine", "staugustine");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "tallahassee")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "tampa bay area")
                            {
                                string rv = s.Replace("tampa bay area", "tampa");
                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "treasure coast")
                            {
                                string rv = s.Replace("treasure coast", "treasure");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "palm beach county")
                            {
                                string rv = s.Replace("palm beach county", "miami");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }                       
                    }
                    else if (cmbstate.Text == "Georgia")
                    {
                        string[] arr = { "albany","athens","atlanta","augusta","brunswick","columbus","macon / warner robins","northwest GA","savannah / hinesville","statesboro","valdosta" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "albany")
                            {
                                string rv = s.Replace("albany", "albanyga");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "athens")
                            {
                                string rv = s.Replace("athens", "athensga");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "atlanta")
                            {                              
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "augusta")
                            {                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "brunswick")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "columbus")
                            {
                                string rv = s.Replace("columbus", "columbusga");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "macon / warner robins")
                            {
                                string rv = s.Replace("macon / warner robins", "macon");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "northwest GA")
                            {
                                string rv = s.Replace("northwest GA", "nwga");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "savannah / hinesville")
                            {
                                string rv = s.Replace("savannah / hinesville", "savannah");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "statesboro")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "valdosta")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Hawaii")
                    {
                        string[] arr = { "hawaii" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "hawaii")
                            {
                                string rv = s.Replace("hawaii", "honolulu");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Idaho")
                    {
                        string[] arr = { "boise","east idaho","lewiston / clarkston","twin falls" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "boise")
                            {                              
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "east idaho")
                            {
                                string rv = s.Replace("east idaho", "eastidaho");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lewiston / clarkston")
                            {
                                string rv = s.Replace("lewiston / clarkston", "lewiston");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "twin falls")
                            {
                                string rv = s.Replace("twin falls", "twinfalls");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Illinois")
                    {
                        string[] arr = { "bloomington-normal","champaign urbana","chicago","decatur","la salle co","mattoon-charleston","peoria","rockford","southern illinois","springfield","western IL" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "bloomington-normal")
                            {
                                string rv = s.Replace("bloomington-normal", "bn");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "champaign urbana")
                            {
                                string rv = s.Replace("champaign urbana", "chambana");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "chicago")
                            {                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "decatur")
                            {                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "la salle co")
                            {
                                string rv = s.Replace("la salle co", "lasalle");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "mattoon-charleston")
                            {
                                string rv = s.Replace("mattoon-charleston", "mattoon");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "peoria")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "rockford")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "southern illinois")
                            {
                                string rv = s.Replace("southern illinois", "carbondale");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "springfield")
                            {
                                string rv = s.Replace("springfield", "springfieldil");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "western IL")
                            {
                                string rv = s.Replace("western IL", "quincy");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Indiana")
                    {
                        string[] arr = { "bloomington", "evansville", "fort wayne", "indianapolis", "kokomo", "lafayette / west lafayette", "muncie / anderson", "richmond", "south bend / michiana", "terre haute" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "bloomington")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "evansville")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "fort wayne")
                            {
                                string rv = s.Replace("fort wayne", "fortwayne");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "indianapolis")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }

                            }
                            else if (s == "kokomo")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lafayette / west lafayette")
                            {
                                string rv = s.Replace("lafayette / west lafayette", "tippecanoe");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lafayette / west lafayette")
                            {
                                string rv = s.Replace("lafayette / west lafayette", "tippecanoe");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "muncie / anderson")
                            {
                                string rv = s.Replace("muncie / anderson", "muncie");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "richmond")
                            {
                                string rv = s.Replace("richmond", "richmondin");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "south bend / michiana")
                            {
                                string rv = s.Replace("south bend / michiana", "southbend");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "terre haute")
                            {
                                string rv = s.Replace("terre haute", "terrehaute");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Iowa")
                    {
                        string[] arr = { "ames","cedar rapids","des moines","dubuque","fort dodge","iowa city","mason city","quad cities","sioux city","southeast IA","waterloo / cedar falls" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "ames")
                            {                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "cedar rapids")
                            {
                                string rv = s.Replace("cedar rapids", "cedarrapids");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "des moines")
                            {
                                string rv = s.Replace("des moines", "desmoines");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "dubuque")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "fort dodge")
                            {
                                string rv = s.Replace("fort dodge", "fortdodge");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "iowa city")
                            {
                                string rv = s.Replace("iowa city", "iowacity");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "mason city")
                            {
                                string rv = s.Replace("mason city", "masoncity");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "quad cities")
                            {
                                string rv = s.Replace("quad cities", "quadcities");
                             
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "sioux city")
                            {
                                string rv = s.Replace("sioux city", "siouxcity");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "southeast IA")
                            {
                                string rv = s.Replace("southeast IA", "ottumwa");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "waterloo / cedar falls")
                            {
                                string rv = s.Replace("waterloo / cedar falls", "waterloo");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Kansas")
                    {
                        string[] arr = { "lawrence","manhattan","northwest KS","salina","southeast KS","southwest KS","topeka","wichita" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "lawrence")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "manhattan")
                            {
                                string rv = s.Replace("manhattan", "ksu");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "northwest KS")
                            {
                                string rv = s.Replace("northwest KS", "nwks");
                             
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "salina")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "southeast KS")
                            {
                                string rv = s.Replace("southeast KS", "seks");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "southwest KS")
                            {
                                string rv = s.Replace("southwest KS", "swks");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "topeka")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "wichita")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Kentucky")
                    {
                        string[] arr = { "bowling green","eastern kentucky","lexington","louisville","owensboro","western KY" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "bowling green")
                            {
                                string rv = s.Replace("bowling green", "bgky");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "eastern kentucky")
                            {
                                string rv = s.Replace("eastern kentucky", "eastky");
                             
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lexington")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "louisville")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "owensboro")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "western KY")
                            {
                                string rv = s.Replace("western KY", "westky");
                             
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Louisiana")
                    {
                        string[] arr = { "baton rouge", "central louisiana", "houma", "lafayette", "lake charles", "monroe", "new orleans", "shreveport" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "baton rouge")
                            {
                                string rv = s.Replace("baton rouge", "batonrouge");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "central louisiana")
                            {
                                string rv = s.Replace("central louisiana", "cenla");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "houma")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                               
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lafayette")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lake charles")
                            {
                                string rv = s.Replace("lake charles", "lakecharles");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "monroe")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "new orleans")
                            {
                                string rv = s.Replace("new orleans", "neworleans");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "shreveport")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Maine")
                    {
                        string[] arr = { "maine" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "maine")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Maryland")
                    {
                        string[] arr = { "annapolis","baltimore","eastern shore","frederick","southern maryland","western maryland" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "annapolis")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "baltimore")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "eastern shore")
                            {
                                string rv = s.Replace("eastern shore", "easternshore");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "frederick")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "southern maryland")
                            {
                                string rv = s.Replace("southern maryland", "smd");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "western maryland")
                            {
                                string rv = s.Replace("western maryland", "westmd");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Massachusetts")
                    {
                        string[] arr = { "boston","cape cod / islands","south coast","western massachusetts","worcester / central MA" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "boston")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "cape cod / islands")
                            {
                                string rv = s.Replace("cape cod / islands", "capecod");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "south coast")
                            {
                                string rv = s.Replace("south coast", "southcoast");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "western massachusetts")
                            {
                                string rv = s.Replace("western massachusetts", "westernmass");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "worcester / central MA")
                            {
                                string rv = s.Replace("worcester / central MA", "worcester");
                             
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Michigan")
                    {
                        string[] arr = { "ann arbor","battle creek","central michigan","detroit metro","flint","grand rapids","holland","jackson","kalamazoo","lansing","monroe","muskegon","northern michigan","port huron","saginaw-midland-baycity","southwest michigan","the thumb","upper peninsula" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "ann arbor")
                            {
                                string rv = s.Replace("ann arbor", "annarbor");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "battle creek")
                            {
                                string rv = s.Replace("battle creek", "battlecreek");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "central michigan")
                            {
                                string rv = s.Replace("central michigan", "centralmich");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "detroit metro")
                            {
                                string rv = s.Replace("detroit metro", "detroit");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "flint")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "grand rapids")
                            {
                                string rv = s.Replace("grand rapids", "grandrapids");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "holland")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "jackson")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "jackson")
                            {
                                string rv = s.Replace("jackson", "jxn");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "kalamazoo")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lansing")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "monroe")
                            {
                                string rv = s.Replace("monroe", "monroemi");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "muskegon")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "northern michigan")
                            {
                                string rv = s.Replace("northern michigan", "nmi");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "port huron")
                            {
                                string rv = s.Replace("port huron", "porthuron");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "saginaw-midland-baycity")
                            {
                                string rv = s.Replace("saginaw-midland-baycity", "saginaw");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "southwest michigan")
                            {
                                string rv = s.Replace("southwest michigan", "swmi");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "the thumb")
                            {
                                string rv = s.Replace("the thumb", "thumb");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "the thumb")
                            {
                                string rv = s.Replace("upper peninsula", "up");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Minnesota")
                    {
                        string[] arr = { "bemidji","brainerd","duluth / superior","mankato","minneapolis / st paul","rochester","southwest MN","st cloud" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "bemidji")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "brainerd")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "duluth / superior")
                            {
                                string rv = s.Replace("duluth / superiorr", "duluth");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "mankato")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "minneapolis / st paul")
                            {
                                string rv = s.Replace("minneapolis / st paul", "minneapolis");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "rochester")
                            {
                                string rv = s.Replace("rochester", "rmn");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "southwest MN")
                            {
                                string rv = s.Replace("southwest MN", "marshall");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "st cloud")
                            {
                                string rv = s.Replace("st cloud", "stcloud");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Mississippi")
                    {
                        string[] arr = { "gulfport / biloxi","hattiesburg","jackson","meridian","north mississippi","southwest MS" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "gulfport / biloxi")
                            {
                                string rv = s.Replace("gulfport / biloxi", "gulfport");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "hattiesburg")
                            {                              
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "jackson")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "meridian")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "north mississippi")
                            {
                                string rv = s.Replace("north mississippi", "northmiss");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "southwest MS")
                            {
                                string rv = s.Replace("southwest MS", "natchez");
                            
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Missouri")
                    {
                        string[] arr = { "columbia / jeff city","joplin","kansas city","kirksville","lake of the ozarks","southeast missouri","springfield","st joseph","st louis" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "columbia / jeff city")
                            {
                                string rv = s.Replace("columbia / jeff city", "columbiamo");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "joplin")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "kansas city")
                            {
                                string rv = s.Replace("kansas city", "kansascity");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "kirksville")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lake of the ozarks")
                            {
                                string rv = s.Replace("lake of the ozarks", "loz");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "southeast missouri")
                            {
                                string rv = s.Replace("southeast missouri", "semo");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "springfield")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "st joseph")
                            {
                                string rv = s.Replace("st joseph", "stjoseph");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "st louis")
                            {
                                string rv = s.Replace("st louis", "stlouis");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Montana")
                    {
                        string[] arr = { "billings","bozeman","butte","great falls","helena","kalispell","missoula","eastern montana" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "billings")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "bozeman")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "butte")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "great falls")
                            {
                                string rv = s.Replace("great falls", "greatfalls");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "helena")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "kalispell")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "missoula")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "eastern montana")
                            {
                                string rv = s.Replace("eastern montana", "montana");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Nebraska")
                    {
                        string[] arr = { "grand island","lincoln","north platte","omaha / council bluffs","scottsbluff / panhandle" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "grand island")
                            {
                                string rv = s.Replace("grand island", "grandisland");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lincoln")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "north platte")
                            {
                                string rv = s.Replace("north platte", "northplatte");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "omaha / council bluffs")
                            {
                                string rv = s.Replace("omaha / council bluffs", "omaha");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "scottsbluff / panhandle")
                            {
                                string rv = s.Replace("scottsbluff / panhandle", "scottsbluff");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Nevada")
                    {
                        string[] arr = { "elko", "las vegas", "reno / tahoe" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "elko")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "las vegas")
                            {
                                string rv = s.Replace("las vegas", "lasvegas");
                            
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "reno / tahoe")
                            {
                                string rv = s.Replace("reno / tahoe", "reno");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "New Hampshire")
                    {
                        string[] arr = { "new hampshire" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "new hampshire")
                            {
                                string rv = s.Replace("new hampshire", "nh");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "New Jersey")
                    {
                        string[] arr = { "central NJ","jersey shore","north jersey","south jersey" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "central NJ")
                            {
                                string rv = s.Replace("central NJ", "cnj");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "jersey shore")
                            {
                                string rv = s.Replace("jersey shore", "jerseyshore");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "north jersey")
                            {
                                string rv = s.Replace("north jersey", "newjersey");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "south jersey")
                            {
                                string rv = s.Replace("south jersey", "southjersey");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "New Mexico")
                    {
                        string[] arr = { "albuquerque","clovis / portales","farmington","las cruces","roswell / carlsbad","santa fe / taos" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "albuquerque")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "clovis / portales")
                            {
                                string rv = s.Replace("clovis / portales", "clovis");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "farmington")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "las cruces")
                            {
                                string rv = s.Replace("las cruces", "lascruces");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "roswell / carlsbad")
                            {
                                string rv = s.Replace("roswell / carlsbad", "roswell");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "santa fe / taos")
                            {
                                string rv = s.Replace("santa fe / taos", "santafe");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "New York")
                    {
                        string[] arr = { "albany","binghamton","buffalo","catskills","chautauqua","elmira-corning","finger lakes","glens falls","hudson valley","ithaca","long island","new york city","oneonta","plattsburgh-adirondacks","potsdam-canton-massena","rochester","syracuse","twin tiers NY/PA","utica-rome-oneida","watertown" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "albany")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "binghamton")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "buffalo")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "catskills")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "chautauqua")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "elmira-corning")
                            {
                                string rv = s.Replace("elmira-corning", "elmira");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "finger lakes")
                            {
                                string rv = s.Replace("finger lakes", "fingerlakes");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "glens falls")
                            {
                                string rv = s.Replace("glens falls", "glensfalls");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "hudson valley")
                            {
                                string rv = s.Replace("hudson valley", "hudsonvalley");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "ithaca")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "long island")
                            {
                                string rv = s.Replace("long island", "longisland");
                             
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "oneonta")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "plattsburgh-adirondacks")
                            {
                                string rv = s.Replace("plattsburgh-adirondacks", "plattsburgh");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "potsdam-canton-massena")
                            {
                                string rv = s.Replace("potsdam-canton-massena", "potsdam");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "rochester")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "syracuse")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "twin tiers NY/PA")
                            {
                                string rv = s.Replace("twin tiers NY/PA", "twintiers");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "utica-rome-oneida")
                            {
                                string rv = s.Replace("utica-rome-oneida", "utica");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "watertown")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "North Carolina")
                    {
                        string[] arr = { "asheville","boone","charlotte","eastern NC","fayetteville","greensboro","hickory / lenoir","jacksonville","outer banks","raleigh / durham / CH","wilmington","winston-salem" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "asheville")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "boone")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "charlotte")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "eastern NC")
                            {
                                string rv = s.Replace("eastern NC", "eastnc");
                             
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "fayetteville")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "greensboro")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "hickory / lenoir")
                            {
                                string rv = s.Replace("hickory / lenoir", "hickory");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "jacksonville")
                            {
                                string rv = s.Replace("jacksonville", "onslow");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "outer banks")
                            {
                                string rv = s.Replace("outer banks", "outerbanks");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "raleigh / durham / CH")
                            {
                                string rv = s.Replace("raleigh / durham / CH", "raleigh");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "wilmington")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "winston-salem")
                            {
                                string rv = s.Replace("winston-salem", "winstonsalem");
                           
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "North Dakota")
                    {
                        string[] arr = { "bismarck","fargo / moorhead","grand forks","north dakota" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "bismarck")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "fargo / moorhead")
                            {
                                string rv = s.Replace("fargo / moorhead", "fargo");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                              
                            }
                            else if (s == "grand forks")
                            {
                                string rv = s.Replace("grand forks", "grandforks");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "north dakota")
                            {
                                string rv = s.Replace("north dakota", "nd");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Ohio")
                    {
                        string[] arr = { "akron / canton","ashtabula","athens","chillicothe","cincinnati","cleveland","columbus","dayton / springfield","lima / findlay","mansfield","sandusky","toledo","tuscarawas co","youngstown","zanesville / cambridge" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "akron / canton")
                            {
                                string rv = s.Replace("akron / canton", "akroncanton");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "ashtabula")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "athens")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "chillicothe")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "cincinnati")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "cleveland")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "columbus")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "dayton / springfield")
                            {
                                string rv = s.Replace("dayton / springfield", "dayton");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lima / findlay")
                            {
                                string rv = s.Replace("lima / findlay", "limaohio");
                             
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "mansfield")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "sandusky")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "toledo")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "tuscarawas co")
                            {
                                string rv = s.Replace("tuscarawas co", "tuscarawas");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "youngstown")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "zanesville / cambridge")
                            {
                                string rv = s.Replace("zanesville / cambridge", "zanesville");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Oklahoma")
                    {
                        string[] arr = { "lawton","northwest OK","oklahoma city","stillwater","tulsa" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "lawton")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "northwest OK")
                            {
                                string rv = s.Replace("northwest OK", "enid");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "oklahoma city")
                            {
                                string rv = s.Replace("oklahoma city", "oklahomacity");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "stillwater")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "tulsa")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Oregon")
                    {
                        string[] arr = { "bend","corvallis/albany","east oregon","eugene","klamath falls","medford-ashland","oregon coast","portland","roseburg","salem" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "bend")
                            {                                
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "corvallis/albany")
                            {
                                string rv = s.Replace("corvallis/albany", "corvallis");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "east oregon")
                            {
                                string rv = s.Replace("east oregon", "eastoregon");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "eugene")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "klamath falls")
                            {
                                string rv = s.Replace("klamath falls", "klamath");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "medford-ashland")
                            {
                                string rv = s.Replace("medford-ashland", "medford");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "oregon coast")
                            {
                                string rv = s.Replace("oregon coast", "oregoncoast");
                             
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "portland")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "roseburg")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "salem")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }

                    else if (cmbstate.Text == "Pennsylvania")
                    {
                        string[] arr = { "altoona-johnstown","cumberland valley","erie","harrisburg","lancaster","lehigh valley","meadville","philadelphia","pittsburgh","poconos","reading","scranton / wilkes-barre","state college","williamsport","york" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "altoona-johnstown")
                            {
                                string rv = s.Replace("altoona-johnstown", "altoona");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "cumberland valley")
                            {
                                string rv = s.Replace("cumberland valley", "chambersburg");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "erie")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "harrisburg")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lancaster")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lehigh valley")
                            {
                                string rv = s.Replace("lehigh valley", "allentown");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "meadville")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "philadelphia")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "pittsburgh")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "poconos")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "reading")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "scranton / wilkes-barre")
                            {
                                string rv = s.Replace("scranton / wilkes-barre", "scranton");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "state college")
                            {
                                string rv = s.Replace("state college", "pennstate");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "williamsport")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "york")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Rhode Island")
                    {
                        string[] arr = { "rhode island" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "rhode island")
                            {
                                string rv = s.Replace("rhode island", "providence");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "South Carolina")
                    {
                        string[] arr = { "charleston","columbia","florence","greenville / upstate","hilton head","myrtle beach" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "charleston")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "columbia")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "florence")
                            {
                                string rv = s.Replace("florence", "florencesc");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "greenville / upstate")
                            {
                                string rv = s.Replace("greenville / upstate", "greenville");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "hilton head")
                            {
                                string rv = s.Replace("hilton head", "hiltonhead");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "myrtle beach")
                            {
                                string rv = s.Replace("myrtle beach", "myrtlebeach");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "South Dakota")
                    {
                        string[] arr = { "northeast SD","pierre / central SD","rapid city / west SD","sioux falls / SE SD","south dakota" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "northeast SD")
                            {
                                string rv = s.Replace("northeast SD", "nesd");
                           
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "pierre / central SD")
                            {
                                string rv = s.Replace("pierre / central SD", "csd");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "rapid city / west SD")
                            {
                                string rv = s.Replace("rapid city / west SD", "rapidcity");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "sioux falls / SE SD")
                            {
                                string rv = s.Replace("sioux falls / SE SD", "siouxfalls");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "south dakota")
                            {
                                string rv = s.Replace("south dakota", "sd");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Tennessee")
                    {
                        string[] arr = { "chattanooga", "clarksville", "cookeville", "jackson", "knoxville", "memphis", "nashville", "tri-cities" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "chattanooga")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "clarksville")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "cookeville")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "jackson")
                            {
                                string rv = s.Replace("jackson", "jacksontn");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "knoxville")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "memphis")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "nashville")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "tri-cities")
                            {
                                string rv = s.Replace("tri-cities", "tricities");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Texas")
                    {
                        string[] arr = { "abilene","amarillo","austin","beaumont / port arthur","brownsville","college station","corpus christi","dallas / fort worth","deep east texas","del rio / eagle pass","el paso","galveston","houston","killeen / temple / ft hood","laredo","lubbock","mcallen / edinburg","odessa / midland","san angelo","san antonio","san marcos","southwest TX","texoma","tyler / east TX","victoria","waco","wichita falls" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "abilene")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                               
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "amarillo")
                            {                              
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "austin")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "beaumont / port arthur")
                            {
                                string rv = s.Replace("beaumont / port arthur", "beaumont");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "college station")
                            {
                                string rv = s.Replace("college station", "collegestation");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "corpus christi")
                            {
                                string rv = s.Replace("corpus christi", "corpuschristi");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "dallas / fort worth")
                            {
                                string rv = s.Replace("dallas / fort worth", "dallas");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "deep east texas")
                            {
                                string rv = s.Replace("deep east texas", "nacogdoches");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "del rio / eagle pass")
                            {
                                string rv = s.Replace("del rio / eagle pass", "delrio");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "el paso")
                            {
                                string rv = s.Replace("el paso", "elpaso");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "galveston")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "houston")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "killeen / temple / ft hood")
                            {
                                string rv = s.Replace("killeen / temple / ft hood", "killeen");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "laredo")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lubbock")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "mcallen / edinburg")
                            {
                                string rv = s.Replace("mcallen / edinburg", "mcallen");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "odessa / midland")
                            {
                                string rv = s.Replace("odessa / midland", "odessa");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "san angelo")
                            {
                                string rv = s.Replace("san angelo", "sanangelo");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "san antonio")
                            {
                                string rv = s.Replace("san antonio", "sanantonio");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "san marcos")
                            {
                                string rv = s.Replace("san marcos", "sanmarcos");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "southwest TX")
                            {
                                string rv = s.Replace("southwest TX", "bigbend");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "texoma")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "tyler / east TX")
                            {
                                string rv = s.Replace("tyler / east TX", "easttexas");
                           
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "victoria")
                            {
                                string rv = s.Replace("victoria", "victoriatx");
                             
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "waco")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "wichita falls")
                            {
                                string rv = s.Replace("wichita falls", "wichitafalls");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Utah")
                    {
                        string[] arr = { "logan","ogden-clearfield","provo / orem","salt lake city","st george" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "logan")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "ogden-clearfield")
                            {
                                string rv = s.Replace("ogden-clearfield", "ogden");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "provo / orem")
                            {
                                string rv = s.Replace("provo / orem", "provo");
                            
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "salt lake city")
                            {
                                string rv = s.Replace("salt lake city", "saltlakecity");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "st george")
                            {
                                string rv = s.Replace("st george", "stgeorge");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Vermont")
                    {
                        string[] arr = { "vermont" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "vermont")
                            {
                                string rv = s.Replace("vermont", "burlington");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Virginia")
                    {
                        string[] arr = { "charlottesville","danville","fredericksburg","hampton roads","harrisonburg","lynchburg","new river valley","richmond","roanoke","southwest VA","winchester" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "charlottesville")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "danville")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "fredericksburg")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "hampton roads")
                            {
                                string rv = s.Replace("hampton roads", "norfolk");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "harrisonburg")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "lynchburg")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "new river valley")
                            {
                                string rv = s.Replace("new river valley", "blacksburg");
                             
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "richmond")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "roanoke")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "southwest VA")
                            {
                                string rv = s.Replace("southwest VA", "swva");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "winchester")
                            {                               
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Washington")
                    {
                        string[] arr = { "bellingham","kennewick-pasco-richland","moses lake","olympic peninsula","pullman / moscow","seattle-tacoma","skagit / island / SJI","spokane / coeur d'alene","wenatchee","yakima" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "bellingham")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "kennewick-pasco-richland")
                            {
                                string rv = s.Replace("kennewick-pasco-richland", "kpr");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "moses lake")
                            {
                                string rv = s.Replace("moses lake", "moseslake");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "olympic peninsula")
                            {
                                string rv = s.Replace("olympic peninsula", "olympic");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "pullman / moscow")
                            {
                                string rv = s.Replace("pullman / moscow", "pullman");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "seattle-tacoma")
                            {
                                string rv = s.Replace("seattle-tacoma", "seattle");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "skagit / island / SJI")
                            {
                                string rv = s.Replace("skagit / island / SJI", "skagit");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "spokane / coeur d'alene")
                            {
                                string rv = s.Replace("spokane / coeur d'alene", "spokane");
                             
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "wenatchee")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "yakima")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "West Virginia")
                    {
                        string[] arr = { "charleston","eastern panhandle","huntington-ashland","morgantown","northern panhandle","parkersburg-marietta","southern WV","west virginia (old)" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "charleston")
                            {
                                string rv = s.Replace("charleston", "charlestonwv");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "eastern panhandle")
                            {
                                string rv = s.Replace("eastern panhandle", "martinsburg");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "huntington-ashland")
                            {
                                string rv = s.Replace("huntington-ashland", "huntington");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "morgantown")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "northern panhandle")
                            {
                                string rv = s.Replace("northern panhandle", "wheeling");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "parkersburg-marietta")
                            {
                                string rv = s.Replace("parkersburg-marietta", "parkersburg");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "southern WV")
                            {
                                string rv = s.Replace("southern WV", "swv");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "west virginia (old)")
                            {
                                string rv = s.Replace("west virginia (old)", "wv");
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Wisconsin")
                    {
                        string[] arr = { "appleton-oshkosh-FDL","eau claire","green bay","janesville","kenosha-racine","la crosse","madison","milwaukee","northern WI","sheboygan","wausau" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "appleton-oshkosh-FDL")
                            {
                                string rv = s.Replace("appleton-oshkosh-FDL", "appleton");  
                              
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "eau claire")
                            {
                                string rv = s.Replace("eau claire", "eauclaire");
                            
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "green bay")
                            {
                                string rv = s.Replace("green bay", "greenbay");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;
                                
                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "janesville")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "kenosha-racine")
                            {
                                string rv = s.Replace("kenosha-racine", "racine");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "la crosse")
                            {
                                string rv = s.Replace("la crosse", "lacrosse");
                                
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "madison")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "milwaukee")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "northern WI")
                            {
                                string rv = s.Replace("northern WI", "northernwi");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "sheboygan")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "wausau")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Wyoming")
                    {
                        string[] arr = { "wyoming" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "wyoming")
                            {
                                string searchuri = "http://" + s + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + s + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                    else if (cmbstate.Text == "Territories")
                    {
                        string[] arr = { "guam-micronesia","puerto rico","U.S. virgin islands" };
                        progressBar.Visible = true;
                        progressBar.Minimum = 0;
                        progressBar.Maximum = arr.Length;
                        progressBar.Value = 1;
                        progressBar.Step = 1;
                        foreach (string s in arr)
                        {
                            if (s == "guam-micronesia")
                            {
                                string rv = s.Replace("guam-micronesia", "micronesia");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "puerto rico")
                            {
                                string rv = s.Replace("puerto rico", "puertorico");
                               
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                            else if (s == "U.S. virgin islands")
                            {
                                string rv = s.Replace("U.S. virgin islands", "virgin");
                             
                                string searchuri = "http://" + rv + baseuri + txtkeyword.Text;

                                string additionalurl = "http://" + rv + ".craigslist.org";

                                MatchUrl(searchuri, additionalurl, cmbjob.Text, cmbstate.Text, txtkeyword.Text);
                                if (progressBar.Value != progressBar.Maximum)
                                {
                                    progressBar.PerformStep();
                                }
                            }
                        }
                    }
                }               
               MessageBox.Show("Search Finished");
               
             }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MatchUrl(string searchuri1, string url, string cmbjob, string cmbstate, string keyword)
        {
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(searchuri1);
            HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();
            StreamReader sr = new StreamReader(httpRes.GetResponseStream());       
            string responseData = sr.ReadToEnd();
            string pattern = @"href=\""(.*?)\""";
            Regex RegExpr = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = RegExpr.Match(responseData);
            while (match.Success)
            {                    
                    string dum = match.Groups[1].Value;
                    if (cmbjob == "All Jobs")
                    {
                        string[] arr = new string[] { "Accounting + Finance", "Admin + Office", "Arch + Engineering", "Art + Media + Design", "Biotech + Science", "Business + Management", "Customer Service", "Education", "Food + Bev + Hosp", "General Labor", "Government", "Human Resources", "Internet Engineers", "Legal + Paralegal", "Manufacturing", "Marketing + Pr + Ad", "Nonprofit Sector", "Real Estate", "Retail + Wholesale", "Sales + Biz Dev", "Salon + Spa + Fitness", "Security", "Skilled Trade + Craft", "Software + Ga + Dba", "Systems + Network", "Technical Support", "Transport", "Tv + Film + Video", "Web + Info Design", "Writing + Editing", "[ETC]", "[Part-Time]" };
                        foreach (string s in arr)
                        {
                            if ((dum.StartsWith("/") == true && dum.EndsWith(".html") == true))
                            {
                                WriteToLog(System.AppDomain.CurrentDomain.BaseDirectory + cmbjob + " " + cmbstate + " " + keyword + DateTime.Now.ToString("  dd-MM-yyyy-hh") + ".xls", url + match.Groups[1].Value);
                            }  
                        }
                    }
                    else if (cmbjob == "Medical + Health")
                    {
                        if ((dum.StartsWith("/") == true && dum.EndsWith(".html") == true))
                        {
                            WriteToLog(System.AppDomain.CurrentDomain.BaseDirectory + cmbjob + " " + cmbstate + " " + keyword + DateTime.Now.ToString("  dd-MM-yyyy-hh") + ".xls", url + match.Groups[1].Value);
                        }                        
                    }             
                match = match.NextMatch();
            }
        }
       
        public void WriteToLog(string file, string message)
        {
            using (StreamWriter w = File.AppendText(file))
            {                
                w.WriteLine(message);
                w.Close();
            }
        }
    }         
}
    

