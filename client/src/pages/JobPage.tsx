import { useQuery } from '@tanstack/react-query';
import { PlusIcon } from 'lucide-react';
import { useState } from 'react';
import { Spinner } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import { JobsTable } from '../Components/JobsTable';
import { Pagination } from '../Components/Pagination';
import { apiService } from '../services/apiService';
import { JobsResponse } from '../types/jobs';

export const JobsPage = () => {
  const [currentPage, setCurrentPage] = useState(1);
  const navigate = useNavigate();
  const pageSize = 10;
  const { data, isError, isLoading } = useQuery<JobsResponse>({
    queryKey: ['jobs', currentPage],
    queryFn: async () => {
      await apiService.post(`/api/seed`);

      const res = await apiService.get(
        `/api/jobapplication?pageNumber=${currentPage}&pageSize=${pageSize}`
      );

      return res.data;
    },
  });

  const handleEdit = (id: number) => {
    console.log('Edit job:', id);
  };

  const handlePageChange = (page: number) => {
    setCurrentPage(page);
  };

  return (
    <div className='min-h-screen bg-gray-50 py-8'>
      <div className='max-w-7xl mx-auto px-4 sm:px-6 lg:px-8'>
        <div className='bg-white rounded-lg shadow'>
          <div className='px-6 py-4 border-b border-gray-200 flex justify-between items-center'>
            <h1 className='text-2xl font-semibold text-gray-800'>
              Job Applications
            </h1>
            <button
              onClick={() => navigate('/job/add')}
              className='inline-flex items-center px-4 py-2 bg-blue-600 text-white rounded-md hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 transition-colors duration-150'
            >
              <PlusIcon className='h-4 w-4 mr-1' />
              Add Job
            </button>
          </div>
          <div className='px-6 py-4'>
            {isLoading ? (
              <div className='flex justify-center py-4'>
                <Spinner animation='border'>
                  <span className='sr-only'>Loading...</span>
                </Spinner>
              </div>
            ) : isError ? (
              <div className='flex justify-center py-4'>
                <span className='text-red-500'>
                  An error occurred while fetching the job data. Please try
                  again later.
                </span>
              </div>
            ) : data ? (
              <>
                <JobsTable jobs={data.data} onEdit={handleEdit} />
                <Pagination
                  currentPage={currentPage}
                  totalPages={Math.ceil(data.totalItemsCount / pageSize)}
                  onPageChange={handlePageChange}
                />
              </>
            ) : null}
          </div>
        </div>
      </div>
    </div>
  );
};
