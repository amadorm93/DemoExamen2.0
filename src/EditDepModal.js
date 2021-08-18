import React, { Component } from 'react';
import axios from 'axios';
import { Modal, Button, Form } from 'react-bootstrap';

export class EditDepModal extends Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChangeName = this.handleChangeName.bind(this);
        this.handleChangeEmpleado = this.handleChangeEmpleado.bind(this);
        
    }

    handleChangeName(event) {
        this.setState({ nombre: event.target.value });
    }
    handleChangeEmpleado(event) {
        this.setState({ noEmpleados: event.target.value });
    }

    async handleSubmit(event) {
        event.preventDefault();
        const params = {
            idDepartamento: this.props.idD,
            nombre: this.state.nombre,
            noEmpleados: this.state.noEmpleados
          
        };
        console.log(params);
        await axios.put(process.env.REACT_APP_API + 'departamento/'+this.props.idD, params).then((res) => { alert("Departamento Modificado") }).catch((e) => { alert(e.message) });
    }
    render() {

        return (
            <div className="container">

                <Modal
                    {...this.props}
                    size="lg"
                    aria-labelledby="contained-modal-title-vcenter"
                    centered
                >
                    <Modal.Header clooseButton>
                        <Modal.Title id="contained-modal-title-vcenter">
                            Edit Department
                        </Modal.Title>
                    </Modal.Header>


                    <Form onSubmit={this.handleSubmit}>
                        <Modal.Body>
                            <div className="form-group">
                                <label>Nombre: </label>
                                <br />
                                <input type="text" className="form-control" name="NombreDepartamento" defaultValue={this.props.nombreD} onChange={this.handleChangeName} />
                                <br />
                                <label>Numero de empleados: </label>
                                <br />
                                <input type="text" className="form-control" name="NoEmpleados" defaultValue={this.props.noE} onChange={this.handleChangeEmpleado} />
                                <br />
                            </div>

                        </Modal.Body>

                        <Modal.Footer>
                            <Button variant="primary" type="submit" onSubmit={this.handleSubmit}>
                                Update Department
                            </Button>
                            <Button variant="danger" onClick={this.props.onHide}>Close</Button>
                        </Modal.Footer>


                    </Form>
                </Modal>

            </div>
        )
    }

}