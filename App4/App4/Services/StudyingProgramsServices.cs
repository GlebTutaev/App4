using App4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SelectionCommittee.Services
{
    public class StudyingProgramsServices : IStudyingProgramsServices
    {

        string Base_url = "https://mosap-orenburg.ru/output.json";


        public async Task<ObservableCollection<StudyingPrograms>> getProgram()
        {
            string url = Base_url;

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(url);

            if (message.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result =  await message.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<ObservableCollection<StudyingPrograms>>(result);
                return json;
            }

            return null;
        }
    }
}
