using JobTrackerApplication.DAL.Models;
using JobTrackerApplication.Entity.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.BLL.Helpers
{
    public static class JobTranformation
    {
        public static Job TransformAPIToDAL(this JobViewModel itemModel)
        {
            if (itemModel == null)
            {
                return null;
            }
            var item = new Job()
            {
                CompanyName = itemModel.CompanyName,
                Position = itemModel.Position

            };

            return item;
        }

        public static CompanyListViewModelcs TransformDALToAPICompany(this Job itemModel)
        {
            if (itemModel == null)
            {
                return null;
            }
            var item = new CompanyListViewModelcs()
            {
                Company = itemModel.CompanyName,
               

            };

            return item;
        }
        public static JobViewModel TransformDALToAPI(this Job itemModel)
        {
            if (itemModel == null)
            {
                return null;
            }
            var item = new JobViewModel()
            {
                CompanyName = itemModel.CompanyName,
                Position = itemModel.Position


            };

            return item;
        }

        public static JobPositionViewModel TransformDALToAPIPosition(this Job itemModel)
        {
            if (itemModel == null)
            {
                return null;
            }
            var item = new JobPositionViewModel()
            {
                position = itemModel.Position,


            };

            return item;
        }

    }
}
