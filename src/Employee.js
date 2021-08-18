import React,{Component} from 'react';
import {Table} from 'react-bootstrap';
import { Button,ButtonToolbar } from 'react-bootstrap';


export class Employee extends Component{
    constructor(props){
        super(props);
        this.state={deps:[]}
    }

    refreshList(){
        fetch(process.env.REACT_APP_API+'empleado')
        .then(response=>response.json())
        .then(data=>{
            this.setState({deps:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }
    deleteDep(depid){
        if(window.confirm('Are you sure?')){
            fetch(process.env.REACT_APP_API+'empleado/'+depid,{
                method:'DELETE',
                header:{'Accept':'application/json',
            'Content-Type':'application/json'}
            })
        }
    }
    render(){
        const {deps, depid,depname}=this.state;
        return(
            <div>
                <button onClick={()=>this.setState({addModalShow:true})} className="btn btn-primary">Insertar Nuevo Empleado</button>
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Numero de Empleado</th>
                        <th>Puesto</th>
                        <th>Acciones</th>
                    </thead>
                    <tbody>
                        {deps.map(dep=>
                        <tr key={dep.id}>
                            <td>{dep.id}</td>
                            <td>{dep.nombre}</td>
                            <td>{dep.appat}</td>
                            <td>{dep.numempleado}</td>
                            <td>{dep.puesto}</td>
                            <td>
                <button className="btn btn-primary" >Editar</button> {" "}
                <button className="btn btn-primary" onClick={()=>this.deleteDep(dep.id)}>Eliminar</button>{" "}
               
              </td>
                        </tr>)}
                    </tbody>
                </Table>
            </div>
        )
    }
}