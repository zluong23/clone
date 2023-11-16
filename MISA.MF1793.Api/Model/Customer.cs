using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MISA.MF1793.Api.Model
{
    
    public class Customer
    {
        [JsonProperty("Name")]
        public  Guid CustomerId { get; set; }
        [Required(ErrorMessage ="code trong")]
        public String CustomerCode { get; set; }
        public String Email { get; set; }
        public int? Gender { get; set; }
        [Required(ErrorMessage = "ten trong")]
        public string  FullName { get; set; }
        public string GenderName { get
            {
                switch (Gender)
                {
                    case 0:
                        return "Nữ";
                    case 1:
                        return "Nam";
                    default:
                        return "không xác định";
                }
            }
        }
    }
}
