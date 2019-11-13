import { Component, OnInit } from '@angular/core';
import { ExamenService } from 'src/app/service/examen.service';
import { sendRequest } from 'selenium-webdriver/http';
import { Examen } from 'src/app/modelo/examen';

@Component({
  selector: 'app-examen-form',
  templateUrl: './examen-form.component.html',
  styleUrls: ['./examen-form.component.css']
})
export class ExamenFormComponent implements OnInit {

  examen: Examen;

  constructor(private service: ExamenService) { }

  ngOnInit() {
   // alert('send request to back');
    this.sendRequest();
  }

  sendRequest(){
    this.service.findAll().subscribe(
      data => {
       this.examen=data;
        console.log(data);
      },
      error => {
        console.log(error.error);
      }
);
  }

}
