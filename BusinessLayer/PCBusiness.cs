using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PCBusiness
    {
        private readonly PCRepository pcRepository;

        public PCBusiness()
        {
            this.pcRepository = new PCRepository();
        }

        public List<PC> GetAllPC()
        {
            return this.pcRepository.GetAllPC();
        }

        public bool InsertPC(PC p)
        {
            if(this.pcRepository.InsertPC(p) > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdatePC(PC p)
        {
            if (this.pcRepository.UpdatePC(p) > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeletePC(PC p)
        {
            if (this.pcRepository.DeletePC(p) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
