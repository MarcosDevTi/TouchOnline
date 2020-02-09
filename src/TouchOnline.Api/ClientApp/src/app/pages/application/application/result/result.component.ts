import { Component, OnInit, Input, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Resultado } from 'src/app/pages/lessons/models/Resultado';
import { ResultDto } from 'src/app/pages/lessons/lesson.service';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<ResultComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ResultDto,
    ) {}
  @Input() resultado: any;

    stars: string[];
ok = 'star';
notOk = 'star_border';

  scores = [
    { num: 0, values: [this.notOk, this.notOk, this.notOk, this.notOk, this.notOk]},
    { num: 1, values: [this.ok, this.notOk, this.notOk, this.notOk, this.notOk]},
    { num: 2, values: [this.ok, this.ok, this.notOk, this.notOk, this.notOk]},
    { num: 3, values: [this.ok, this.ok, this.ok, this.notOk, this.notOk]},
    { num: 4, values: [this.ok, this.ok, this.ok, this.ok, this.notOk]},
    { num: 5, values: [this.ok, this.ok, this.ok, this.ok, this.ok]},
  ];

    ngOnInit() {
      console.log('pagina de resultado', this.data);
      this.stars = this.scores[this.data.stars].values;
    }

    onNoClick(): void {
      this.dialogRef.close();
    }

}