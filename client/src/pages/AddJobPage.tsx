import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query';
import { ArrowLeft, Loader2, Plus } from 'lucide-react';
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import { apiService } from '../services/apiService';
import { JOB_STATUSES } from '../types/jobs';

interface FormErrors {
  companyName?: string;
  position?: string;
}

interface FormData {
  companyName: string;
  position: string;
  jobStatus: string;
}

export const AddJobPage = () => {
  const navigate = useNavigate();
  const queryClient = useQueryClient();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [errors, setErrors] = useState<FormErrors>({});
  const [formData, setFormData] = useState<FormData>({
    companyName: '',
    position: '',
    jobStatus: JOB_STATUSES[0],
  });

  const { data: companyList, isLoading: companyLoading } = useQuery<
    { company: string }[]
  >({
    queryKey: ['companies'],
    queryFn: async () => {
      const res = await apiService.get('/api/job');
      return res.data;
    },
  });

  const { data: jobList, isLoading: jobLoading } = useQuery<
    { position: string }[]
  >({
    queryKey: ['positions', formData.companyName],
    queryFn: async () => {
      if (!formData.companyName) return [];
      const res = await apiService.get(
        `/api/job/getJobPosition/${formData.companyName}`
      );
      return res.data;
    },
    enabled: !!formData.companyName,
  });

  const { mutate } = useMutation({
    mutationKey: ['addJob'],
    mutationFn: async (job: FormData) => {
      await apiService.post('/api/JobApplication', job);
    },
    onError: () => {
      toast.error('Failed to add job. Please try again.');
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['jobs'] });
      toast.success('Job added successfully!');
      navigate('/');
    },
  });

  const validateForm = (): boolean => {
    const newErrors: FormErrors = {};
    if (!formData.companyName) newErrors.companyName = 'Company is required';
    if (!formData.position) newErrors.position = 'Position is required';
    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!validateForm()) return;
    setIsSubmitting(true);
    mutate(formData, { onSettled: () => setIsSubmitting(false) });
  };

  const handleInputChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
      ...(name === 'companyName' ? { position: '' } : {}),
    }));
    setErrors((prev) => ({ ...prev, [name]: undefined }));
  };

  return (
    <div className='min-h-screen flex items-center justify-center bg-gray-100 p-6'>
      <div className='w-full max-w-lg bg-white rounded-lg shadow-md p-6'>
        {/* Header */}
        <div className='flex items-center space-x-3 mb-6 border-b pb-4'>
          <button
            onClick={() => navigate('/')}
            className='text-gray-600 hover:text-gray-900'
          >
            <ArrowLeft className='h-5 w-5' />
          </button>
          <h2 className='text-xl font-semibold text-gray-800'>
            Add Job Application
          </h2>
        </div>

        {/* Form */}
        <form onSubmit={handleSubmit} className='space-y-5'>
          {/* Company Dropdown */}
          <div>
            <label className='block text-sm font-medium text-gray-700'>
              Company
            </label>
            <select
              name='companyName'
              value={formData.companyName}
              onChange={handleInputChange}
              className={`w-full mt-1 p-2 border rounded-md focus:outline-none focus:ring-2 ${
                errors.companyName
                  ? 'border-red-500 focus:ring-red-300'
                  : 'border-gray-300 focus:ring-blue-300'
              }`}
            >
              <option value=''>Select a Company</option>
              {companyLoading ? (
                <option>Loading companies...</option>
              ) : (
                companyList?.map(({ company }) => (
                  <option key={company} value={company}>
                    {company}
                  </option>
                ))
              )}
            </select>
            {errors.companyName && (
              <p className='text-red-500 text-sm mt-1'>{errors.companyName}</p>
            )}
          </div>

          {/* Position Dropdown */}
          <div>
            <label className='block text-sm font-medium text-gray-700'>
              Position
            </label>
            <select
              name='position'
              value={formData.position}
              onChange={handleInputChange}
              disabled={!formData.companyName}
              className={`w-full mt-1 p-2 border rounded-md focus:outline-none focus:ring-2 ${
                errors.position
                  ? 'border-red-500 focus:ring-red-300'
                  : 'border-gray-300 focus:ring-blue-300'
              } ${!formData.companyName && 'bg-gray-200 cursor-not-allowed'}`}
            >
              <option value=''>Select a Position</option>
              {jobLoading ? (
                <option>Loading positions...</option>
              ) : (
                jobList?.map(({ position }) => (
                  <option key={position} value={position}>
                    {position}
                  </option>
                ))
              )}
            </select>
            {errors.position && (
              <p className='text-red-500 text-sm mt-1'>{errors.position}</p>
            )}
          </div>

          {/* Status Dropdown */}
          <div>
            <label className='block text-sm font-medium text-gray-700'>
              Status
            </label>
            <select
              disabled={true}
              name='jobStatus'
              value={formData.jobStatus}
              onChange={handleInputChange}
              className='w-full mt-1 p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-300 focus:outline-none bg-gray-200 cursor-not-allowed'
            >
              {JOB_STATUSES.map((status) => (
                <option key={status} value={status}>
                  {status}
                </option>
              ))}
            </select>
          </div>

          {/* Submit Button */}
          <div className='flex justify-end'>
            <button
              type='submit'
              disabled={isSubmitting}
              className='flex items-center px-4 py-2 bg-blue-600 text-white rounded-md hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500 disabled:opacity-50'
            >
              {isSubmitting ? (
                <>
                  <Loader2 className='animate-spin h-4 w-4 mr-2' />{' '}
                  Processing...
                </>
              ) : (
                <>
                  <Plus className='h-4 w-4 mr-2' /> Add Job
                </>
              )}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};
