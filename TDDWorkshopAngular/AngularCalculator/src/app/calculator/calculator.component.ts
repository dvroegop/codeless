import { Component } from '@angular/core';
import { CalculaterInputService } from './calculater.service';


@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent {

  /**
   *
   */
  constructor(private calculatorInputService: CalculaterInputService) {

  }

  getInput() {
    return this.calculatorInputService.getInput().subscribe(val => {
      return val
    });
  }

  add(input: string): number {

    if (input === "") return 0;


    if (input.indexOf(",") == -1) {
      return parseInt(input);
    }

    const splitNum = input.split(',');

    return this.sumInputsArray(splitNum);
  }

  private sumInputsArray(splitNum: string[]) {
    let result = 0;
    for (var i = 0; i < splitNum.length; i++) {
      const parsedVal = parseInt(splitNum[i]);
      if (!isNaN(parsedVal)) {
        result += parsedVal;
      } else {
        throw new Error(splitNum[i] + ' is not a valid number');
      }

    }
    return result;
  }
}

