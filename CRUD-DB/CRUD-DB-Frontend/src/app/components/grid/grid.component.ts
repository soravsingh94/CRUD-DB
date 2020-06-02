import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})

export class GridComponent implements OnInit {

  @Input() rows: any;
  @Input() cols: any;
  @Input() headerName: any;

  ngOnInit() {
    // this.users = [
    //   { id: '1', name: 'kiran1', email: 'kiran@gmail.com' },
    //   { id: '2', name: 'tom', email: 'tom@gmail.com' },
    //   { id: '3', name: 'john', email: 'john@gmail.com' },
    //   { id: '4', name: 'Frank', email: 'frank@gmail.com' },

    // ];
    // this.cols = [
    //   { field: 'id', header: 'Id' },
    //   { field: 'name', header: 'Name' },
    //   { field: 'email', header: 'Email' },
    // ];
  }

}
