import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-pagging-header',
  templateUrl: './pagging-header.component.html',
  styleUrls: ['./pagging-header.component.scss']
})
export class PaggingHeaderComponent {
  @Input() pageNumber:number;
  @Input() pageSize:number;
  @Input() totalCount:number;

}
