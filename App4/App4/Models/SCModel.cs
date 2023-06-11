using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;


namespace SelectionCommittee.Models
{
    public class SCModel
    {
    }

    public class StudyingPrograms
    {
        public string id { get; set; }
        public string pagetitle { get; set; }
        public string introtext { get; set; }
        public string parent { get; set; }


        
        [JsonProperty("tv.img")]
        public string tvimg 
        { get; set; }

        [JsonProperty("tv.price")]
        public string tvprice { get; set; }

        [JsonProperty("tv.options")]
        public List<tvoptionItem> tvoptions { get; set; }

        [JsonProperty("tv.examen")]
        public List<examenItem> tvexamen { get; set; }

        [JsonProperty("tv.ochno")]
        public string tvochno { get; set; }

        [JsonProperty("tv.zaochno")]
        public string tvzaochno { get; set; }

        [JsonProperty("tv.distant")]
        public string tvdistant { get; set; }
    }

    public class tvoptionItem {

        public string MIGX_id { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
    }

    public class examenItem
    {
        public string MIGX_id { get; set; }
        public string predmet { get; set; }
    }

}
