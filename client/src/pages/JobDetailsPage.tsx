import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query';
import { format } from 'date-fns';
import { ArrowLeft } from 'lucide-react';
import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { toast } from 'react-toastify';
import { apiService } from '../services/apiService';
import { Job, JOB_STATUSES } from '../types/jobs';

export const JobDetailsPage = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const queryClient = useQueryClient();
  const [status, setStatus] = useState<string>('Pending');

  const { data: job, isError, isLoading } = useQuery<Job>({
    queryKey: ['job', id],
    queryFn: async () => {
      const res = await apiService.get(`/api/JobApplication/GetJobApplication/${id}`);
      return res.data;
    },
  });

  useEffect(() => {
    if (job) {
      setStatus(job.jobStatus);
    }
  }, [job]);

  const { mutate, isPending } = useMutation({
    mutationKey: ['updateJob', id],
    mutationFn: async () => {
      await apiService.put(`/api/JobApplication`, { id: job?.id, status });
    },
    onError: () => {
      toast.error('Failed to update job status. Please try again.');
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['jobs'] });
      toast.success('Job status updated successfully!');
      navigate('/');
    },
  });

  const handleSave = () => {
    mutate();
  };

  if (isLoading) {
    return (
      <div className="flex justify-center items-center min-h-screen bg-gray-100">
        <p className="text-lg font-medium text-gray-700">Loading job details...</p>
      </div>
    );
  }

  if (isError || !job) {
    return (
      <div className="flex justify-center items-center min-h-screen bg-gray-100">
        <p className="text-lg font-medium text-red-500">Failed to fetch job details.</p>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-gray-100 flex items-center justify-center p-6">
      <div className="w-full max-w-2xl bg-white rounded-lg shadow-lg p-6">
        {/* Header */}
        <div className="flex items-center space-x-3 mb-6">
          <button onClick={() => navigate('/')} className="text-gray-600 hover:text-gray-900">
            <ArrowLeft className="h-5 w-5" />
          </button>
          <h2 className="text-2xl font-semibold text-gray-800">Job Details</h2>
        </div>

        {/* Job Details */}
        <div className="space-y-4">
          <div>
            <label className="block text-sm font-medium text-gray-700">Company Name</label>
            <p className="mt-1 text-lg text-gray-900">{job.companyName}</p>
          </div>

          <div>
            <label className="block text-sm font-medium text-gray-700">Position</label>
            <p className="mt-1 text-lg text-gray-900">{job.position}</p>
          </div>

          <div>
            <label className="block text-sm font-medium text-gray-700">Date Applied</label>
            <p className="mt-1 text-lg text-gray-900">{format(new Date(job.dateApplied), 'MMMM d, yyyy')}</p>
          </div>

          <div>
            <label className="block text-sm font-medium text-gray-700">Status</label>
            <select
              value={status}
              onChange={(e) => setStatus(e.target.value)}
              className="w-full mt-1 p-2 border rounded-md text-gray-700 bg-gray-50 focus:outline-none focus:ring-2 focus:ring-blue-500"
            >
              {JOB_STATUSES.map((status) => (
                <option key={status} value={status}>
                  {status}
                </option>
              ))}
            </select>
          </div>
        </div>

        {/* Buttons */}
        <div className="flex justify-end mt-6">
          <button
            onClick={handleSave}
            disabled={isPending}
            className={`px-5 py-2 rounded-lg text-white font-medium transition ${
              isPending
                ? 'bg-blue-400 cursor-not-allowed'
                : 'bg-blue-600 hover:bg-blue-700'
            }`}
          >
            {isPending ? 'Saving...' : 'Save Changes'}
          </button>
        </div>
      </div>
    </div>
  );
};
