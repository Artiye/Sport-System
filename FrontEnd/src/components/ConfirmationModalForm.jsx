import React from 'react'
import { Modal, Button } from "react-bootstrap";
 
const ConfirmationModalForm = ({ headerText, bodyText, showConfirmModal, confirmDelete, handleCloseConfirmModal}) => {
    return (
      <Modal show={showConfirmModal} onHide={handleCloseConfirmModal} className='text-center'>

        <Modal.Header closeButton>
          <Modal.Title> {headerText} </Modal.Title>
        </Modal.Header>

        <Modal.Body>
          {bodyText}
        </Modal.Body>

        <Modal.Footer>
          <Button variant="danger" onClick={confirmDelete} style={{backgroundColor:"red", border:"none", marginTop:"20px"}}>
            Confirm
          </Button>
          <Button variant="secondary" onClick={handleCloseConfirmModal} style={{backgroundColor:"black", border:"none"}}>
            Cancel
          </Button>
        </Modal.Footer>
        
      </Modal>
    )
}
 
export default ConfirmationModalForm;