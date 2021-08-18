import React,{Component} from 'react';
import axios from 'axios';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class AddEmpModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
        this.handleChangeName=this.handleChangeName.bind(this);
        this.handleChangeEmpleado=this.handleChangeEmpleado.bind(this);
        this.handleChangeGerente=this.handleChangeGerente.bind(this);
    }

    handleChangeName(event){
        this.setState({nombre: event.target.value});
    }
    handleChangeEmpleado(event){
        this.setState({noEmpleados: event.target.value});
    }
    handleChangeGerente(event){
        this.setState({idGerente: event.target.value});
    }

    async handleSubmit(event){
        event.preventDefault();
        const params={
            nombre:this.state.nombre,
            noEmpleados:this.state.noEmpleados,
            idGerente:parseInt(this.state.idGerente)
        };
        console.log(params);
        await axios.post(process.env.REACT_APP_API+'departamento',params).then((res) => { alert("Departamento agregado") }).catch((e) => { alert(e.message) });
        // fetch(process.env.REACT_APP_API+'departamento',{
        //     method:'POST',
        //     headers:{
        //         'Accept':'application/json',
        //         'Content-Type':'application/json'
        //     },
        //     body:{
        //         idDepartamento:null,
        //         nombre:this.state.nombre,
        //         noEmpleados:this.state.noEmpleados,
        //         idGerente:this.state.idGerente
        //     }
        // })
        // .then(res=>res.json())
        // .then((result)=>{
        //     alert(result);
        // },
        // (error)=>{
        //     alert('Failed');
        // })
    }
    render(){
        
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
            Add Department
        </Modal.Title>
    </Modal.Header>
    

        <Form onSubmit={this.handleSubmit}>
        <Modal.Body>
        <div className="form-group">
            <label>Nombre: </label>
            <br />
            <input type="text" className="form-control" name="Nombre" onChange={this.handleChangeName} />
            <br/>
            <label>Numero de empleados: </label>
            <br />
            <input type="text" className="form-control"name="NoEmpleados" onChange={this.handleChangeEmpleado}/>
            <br/>
            <label>IdGerente: </label>
            <br />
            <input type="text" className="form-control" name="IdGerente"onChange={this.handleChangeGerente}/>
            <br/>
          </div>
         
             </Modal.Body>
    
        <Modal.Footer>
          <Button variant="primary" type="submit" onSubmit={this.handleSubmit}>
                                Add Department
                        </Button>
        <Button variant="danger" onClick={this.props.onHide}>Close</Button>
        </Modal.Footer>


        </Form>
        </Modal>

            </div>
        )
    }

}