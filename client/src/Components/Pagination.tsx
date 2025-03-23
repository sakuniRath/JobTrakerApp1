interface PaginationProps {
  currentPage: number;
  totalPages: number;
  onPageChange: (page: number) => void;
}
export const Pagination = ({
  currentPage,
  totalPages,
  onPageChange,
}: PaginationProps) => {
  return (
    <div className='flex items-center justify-center space-x-2 mt-4'>
      <button
        onClick={() => onPageChange(currentPage - 1)}
        disabled={currentPage === 1}
        className='px-3 py-1 rounded border disabled:opacity-50 hover:bg-gray-50'
      >
        Previous
      </button>
      <span className='text-sm text-gray-600'>
        Page {currentPage} of {totalPages}
      </span>
      <button
        onClick={() => onPageChange(currentPage + 1)}
        disabled={currentPage === totalPages}
        className='px-3 py-1 rounded border disabled:opacity-50 hover:bg-gray-50'
      >
        Next
      </button>
    </div>
  );
};
