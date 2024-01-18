import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const handleApiError = (error, defaultMessage) => {
  if (error.response) {
    const responseData = error.response.data;
    if (responseData && responseData.errors) {
      const firstErrorField = Object.keys(responseData.errors)[0]; 
      const firstErrorMessage = responseData.errors[firstErrorField][0]; 
      toast.error(firstErrorMessage, { closeButton: <div style={{ width: "25%" }}></div> });
    } else { toast.error(responseData.message, {closeButton: <div style={{ width: "25%" }}></div> });
    }
  } else {
    toast.error(defaultMessage, { closeButton: <div style={{ width: "25%" }}></div>});
  }
};

export default handleApiError;


