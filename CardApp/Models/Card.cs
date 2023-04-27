using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardApp.Models
{
    public class Card
    {
        public string Name { get; set; }
        public string Team { get; set; }
        public string Position { get; set; } //Auto Implemented properties

        private string imageURL; //

        public  string Image
        {
            
            set
            {
                imageURL = value;
            }
            get
            {
                return imageURL;
            }
        }

        //Construction
        public Card(string name, string team, string position, string image)
        {
            Name = name;
            Team = team;
            Position = position;
            Image = image;

        }
        
    }
}
