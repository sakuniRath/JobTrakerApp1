import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { Route, BrowserRouter as Router, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import { JobDetailsPage } from './pages/JobDetailsPage';
import { JobsPage } from './pages/JobPage';
import { JobViewPage } from './pages/JobViewPage';
import { AddJobPage } from './pages/AddJobPage';

const queryClient = new QueryClient();

export default function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <ToastContainer />
      <Router>
        <Routes>
          <Route path='/' element={<JobsPage />} />
          <Route path='/job/:id/edit' element={<JobDetailsPage />} />
          <Route path='/job/:id' element={<JobViewPage />} />
          <Route path="/job/add" element={<AddJobPage />} />
        </Routes>
      </Router>
    </QueryClientProvider>
  );
}
