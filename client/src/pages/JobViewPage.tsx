import { useQuery } from '@tanstack/react-query';
import { format } from 'date-fns';
import {
  ActivityIcon,
  ArrowLeftIcon,
  BriefcaseIcon,
  BuildingIcon,
  CalendarIcon,
} from 'lucide-react';
import { useNavigate, useParams } from 'react-router-dom';
import { apiService } from '../services/apiService';
import { Job } from '../types/jobs';

export const JobViewPage = () => {
  const { id } = useParams();
  const navigate = useNavigate();

  const {
    data: job,
    isError,
    isLoading,
  } = useQuery<Job>({
    queryKey: ['job', id],
    queryFn: async () => {
      const res = await apiService.get(
        `/api/JobApplication/GetJobApplication/${id}`
      );
      return res.data;
    },
  });

  if (!job) {
    return (
      <div className='min-h-screen bg-gray-50 py-8'>
        <div className='max-w-3xl mx-auto px-4'>
          <div className='bg-white rounded-lg shadow p-6'>
            <h1 className='text-xl text-red-600'>Job not found</h1>
          </div>
        </div>
      </div>
    );
  }
  const getStatusColor = (status: string) => {
    switch (status) {
      case 'Pending':
        return 'bg-yellow-100 text-yellow-800';
      case 'Interview':
        return 'bg-blue-100 text-blue-800';
      case 'Offer':
        return 'bg-green-100 text-green-800';
      case 'Rejected':
        return 'bg-red-100 text-red-800';
      default:
        return 'bg-gray-100 text-gray-800';
    }
  };
  if (!job) {
    return (
      <div className='min-h-screen bg-gray-50 py-8'>
        <div className='max-w-3xl mx-auto px-4'>
          <div className='bg-white rounded-lg shadow p-6'>
            <h1 className='text-xl text-red-600'>Job not found</h1>
          </div>
        </div>
      </div>
    );
  }

  if (isLoading) {
    return (
      <div className='min-h-screen bg-gray-50 py-8'>
        <div className='max-w-3xl mx-auto px-4'>
          <div className='bg-white rounded-lg shadow p-6'>
            <div className='flex justify-center'>
              <span>Loading job details...</span>
            </div>
          </div>
        </div>
      </div>
    );
  }

  if (isError) {
    return (
      <div className='min-h-screen bg-gray-50 py-8'>
        <div className='max-w-3xl mx-auto px-4'>
          <div className='bg-white rounded-lg shadow p-6'>
            <div className='flex justify-center'>
              <span className='text-red-500'>
                An error occurred while fetching the job details. Please try
                again later.
              </span>
            </div>
          </div>
        </div>
      </div>
    );
  }

  return (
    <div className='min-h-screen bg-gray-50 py-8'>
      <div className='max-w-3xl mx-auto px-4'>
        <div className='bg-white rounded-lg shadow-lg overflow-hidden'>
          <div className='px-6 py-4 border-b border-gray-200 flex items-center bg-gray-50'>
            <button
              onClick={() => navigate('/')}
              className='mr-4 text-gray-600 hover:text-gray-900 transition-colors duration-150'
            >
              <ArrowLeftIcon className='h-5 w-5' />
            </button>
            <h1 className='text-2xl font-semibold text-gray-800'>
              Job Application Details
            </h1>
          </div>
          <div className='p-6'>
            <div className='grid gap-8'>
              <div className='flex items-start space-x-4'>
                <BuildingIcon className='h-6 w-6 text-gray-400 mt-1' />
                <div>
                  <h2 className='text-sm font-medium text-gray-500'>Company</h2>
                  <p className='mt-1 text-lg font-medium text-gray-900'>
                    {job.companyName}
                  </p>
                </div>
              </div>
              <div className='flex items-start space-x-4'>
                <BriefcaseIcon className='h-6 w-6 text-gray-400 mt-1' />
                <div>
                  <h2 className='text-sm font-medium text-gray-500'>
                    Position
                  </h2>
                  <p className='mt-1 text-lg font-medium text-gray-900'>
                    {job.position}
                  </p>
                </div>
              </div>
              <div className='flex items-start space-x-4'>
                <CalendarIcon className='h-6 w-6 text-gray-400 mt-1' />
                <div>
                  <h2 className='text-sm font-medium text-gray-500'>
                    Application Date
                  </h2>
                  <p className='mt-1 text-lg font-medium text-gray-900'>
                    {format(new Date(job.dateApplied), 'MMMM d, yyyy')}
                  </p>
                </div>
              </div>
              <div className='flex items-start space-x-4'>
                <ActivityIcon className='h-6 w-6 text-gray-400 mt-1' />
                <div>
                  <h2 className='text-sm font-medium text-gray-500'>Status</h2>
                  <span
                    className={`mt-2 inline-flex px-3 py-1 text-sm font-semibold rounded-full ${getStatusColor(
                      job.jobStatus
                    )}`}
                  >
                    {job.jobStatus}
                  </span>
                </div>
              </div>
            </div>
            <div className='mt-8 flex justify-end'>
              <button
                onClick={() => navigate(`/job/${id}/edit`)}
                className='px-4 py-2 bg-blue-600 text-white rounded-md hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 transition-colors duration-150'
              >
                Edit Application
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
