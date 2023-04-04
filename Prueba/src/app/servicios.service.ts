import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ServiciosService {

  constructor(private http:HttpClient) { }


  getInfo()
  {

    return this.http.get<any>('https://localhost:7145/api/Marca/Marcas');
  
  }
  getInf(valor:string)
  {
    return this.http.get('https://api.copomex.com/query/info_cp/'+valor+'?token=bf0d83d3-fd5c-423f-9663-389ce834b929').pipe(map((resp:any) => resp.map((inf:any)=>({estado:inf.response.estado,municipio:inf.response.municipio,colonia:inf.response.asentamiento}))));
  }

  getsub(v1:string)
  {

    return this.http.get<any>('https://localhost:7145/api/Submarca/'+v1);
  
  }

  getmod(v1:string)
  {

    return this.http.get<any>('https://localhost:7145/api/Modelo/'+v1);
  
  }
  getdes(v1:string)
  {

    return this.http.get<any>('https://localhost:7145/api/Descripcion/'+v1);
  
  }
}
