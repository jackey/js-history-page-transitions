using System;
using System.Collections.Generic;
using System.Linq;

namespace PageTransitions
{
    public class PersonInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonInfoRepository
    {
        private static List<PersonInfo> _personInfo = new List<PersonInfo>
            {
                new PersonInfo { Id = 1, Name = "Bubba Smith", Age = 39 },
                new PersonInfo { Id = 2, Name = "Jack Daniels", Age = 42 },
                new PersonInfo { Id = 3, Name = "Marty McFly", Age = 17 },
                new PersonInfo { Id = 4, Name = "Kermit T. Frog", Age = 28 },
                new PersonInfo { Id = 5, Name = "Ro Bot", Age = 72 },
                new PersonInfo { Id = 6, Name = "Stumpy Talls", Age = 39 },
            };

        public List<PersonInfo> GetPersonInfoList()
        {
            return _personInfo;
        }

        public PersonInfo GetPerson(int id)
        {
            return _personInfo.Find(x => x.Id == id);
        }

        public void SavePerson(PersonInfo peep)
        {
            //Nothing to do since things are held in memory
        }
    }
}