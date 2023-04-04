import { Component, OnInit } from '@angular/core';
import { ServiciosService } from 'src/app/servicios.service';
import { MarcasI } from '../modelos/marca.inteface';

@Component({
  selector: 'app-vista',
  templateUrl: './vista.component.html',
  styleUrls: ['./vista.component.scss']
})
export class VistaComponent implements OnInit{

  Auto = 
  {
    idMarca:'',
    Marca:'',
    Submarca:'',
    IdSubmarca:'',
    Modelo:'',
    Idmodelo:'',
    Descripcion:'',
    IdDescricion:''
  }

  lugar = 
  {
    cp:'',
    estado:'',
    municipio:'',
    colonia:''
  }

  info :any[]=[];

  marcas: any[] = [];
  sub: any[] = [];
  mod: any[] = [];
  des: any[] = [];

  constructor(private Servicios:ServiciosService){}

  ngOnInit(): void {
    this.Servicios.getInfo().subscribe((info:any) =>{
      this.marcas = info.response;
    })  
    
  }
  prueba(valor:string) 
  {
    console.log("Hola "+valor)
    if(valor.length == 5){
    this.Servicios.getInf(valor).subscribe(info =>{
      this.info = info;
      this.lugar.estado = this.info[0].estado;
      this.lugar.municipio = this.info[0].municipio;
    }) 
  }
    console.log(this.info)     
  }

  getSubMarca() {
    var e = (<HTMLInputElement>document.getElementById("op")).value;
    this.Servicios.getsub(e).subscribe((info:any) =>{
      this.sub = info.response;
    })   
  }

  getModelo() {
    var e = (<HTMLInputElement>document.getElementById("op1")).value;
    this.Servicios.getmod(e).subscribe((info:any) =>{
      this.mod = info.response;
    })   
  }

  getDes() {
    var e = (<HTMLInputElement>document.getElementById("op1")).value;
    this.Servicios.getdes(e).subscribe((info:any) =>{
      this.des = info.response;
    })   
  }

}
