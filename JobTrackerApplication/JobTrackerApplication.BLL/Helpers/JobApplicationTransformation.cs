using JobTrackerApplication.DAL.Models;
using JobTrackerApplication.Entity.Jobs;

namespace JobTrackerApplication.BLL.Helpers
{
    public static class JobApplicationTransformation
    {
        public static JobApplicationViewModel TransformDALToAPI(this JobApplication itemModel)
        {
            if (itemModel == null)
            {
                return null;
            }
            var item = new JobApplicationViewModel()
            {
                JobStatus = itemModel.Status,
                DateApplied = itemModel.DateApplied,
                Id = itemModel.Id,
                JobId = itemModel.JobId
            };
            return item;
        }
        public static JobApplication TransformAPIToDAL(this JobApplicationAddViewModel itemViewModel)
        {
            if (itemViewModel == null)
            {
                return null;
            }
            var item = new JobApplication()
            {
                Status = itemViewModel.JobStatus,
                DateApplied = DateTime.UtcNow,
                JobId = itemViewModel.JobId,
                ApplicationUserId = 1 // user management not implement
            };
            return item;
        }

        public static JobApplication TransformAPIToDAL(this JobApplicationUpdateViewModel itemViewModel)
        {
            if (itemViewModel == null)
            {
                return null;
            }
            var item = new JobApplication()
            {
                Status = itemViewModel.status,
                Id= itemViewModel.Id,
            };
            return item;
        }
      

    }
   
}
