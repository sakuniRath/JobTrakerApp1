import { format } from 'date-fns';
import { PencilIcon } from 'lucide-react';
import { useNavigate } from 'react-router-dom';
import { Job } from '../types/jobs';
interface JobsTableProps {
  jobs: Job[];
  onEdit: (id: number) => void;
}
export const JobsTable = ({ jobs }: JobsTableProps) => {
  const navigate = useNavigate();
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
  return (
    <div className='w-full overflow-x-auto'>
      <table className='min-w-full divide-y divide-gray-200'>
        <thead className='bg-gray-50'>
          <tr>
            <th className='px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider'>
              Company Name
            </th>
            <th className='px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider'>
              Position
            </th>
            <th className='px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider'>
              Status
            </th>
            <th className='px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider'>
              Date Applied
            </th>
            <th className='px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider'>
              Actions
            </th>
          </tr>
        </thead>
        <tbody className='bg-white divide-y divide-gray-200'>
          {jobs.map((job) => (
            <tr
              key={job.id}
              onClick={() => navigate(`/job/${job.id}`)}
              className='hover:bg-gray-50 cursor-pointer transition-colors duration-150'
            >
              <td className='px-6 py-4 whitespace-nowrap'>{job.companyName}</td>
              <td className='px-6 py-4 whitespace-nowrap'>{job.position}</td>
              <td className='px-6 py-4 whitespace-nowrap'>
                <span
                  className={`px-2 inline-flex text-xs leading-5 font-semibold rounded-full ${getStatusColor(
                    job.jobStatus
                  )}`}
                >
                  {job.jobStatus}
                </span>
              </td>
              <td className='px-6 py-4 whitespace-nowrap'>
                {format(new Date(job.dateApplied), 'MMM d, yyyy')}
              </td>
              <td className='px-6 py-4 whitespace-nowrap'>
                <button
                  onClick={(e) => {
                    e.stopPropagation();
                    navigate(`/job/${job.id}/edit`);
                  }}
                  className='text-gray-600 hover:text-gray-900 transition-colors duration-150'
                >
                  <PencilIcon className='h-5 w-5' />
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};
