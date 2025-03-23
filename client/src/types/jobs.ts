export interface Job {
  id: number;
  jobStatus: string;
  dateApplied: string;
  companyName: string;
  position: string;
}

export interface JobsResponse {
  data: Job[];
  pageNumber: number;
  pageSize: number;
  totalItemsCount: number;
  pageCount: number;
}

export const JOB_STATUSES = ['Interview', 'Offer', 'Rejected'] as const;
export type JobStatus = (typeof JOB_STATUSES)[number];
