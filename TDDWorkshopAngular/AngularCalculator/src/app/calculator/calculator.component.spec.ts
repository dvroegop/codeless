import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculatorComponent } from './calculator.component';
import { CalculaterInputService } from './calculater.service';

describe('CalculatorComponent', () => {
  let component: CalculatorComponent;
  let fixture: ComponentFixture<CalculatorComponent>;

  let calculatorSpyObject = jasmine.createSpyObj('CalculaterInputService', ['getInput']);
  

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CalculatorComponent],
      providers: [
        { provide: CalculaterInputService, useValue: calculatorSpyObject },
      ]
    });
    fixture = TestBed.createComponent(CalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should return 0 when empty string is passed', () => {
    //arrange 
    calculatorSpyObject.getInput.and.returnValue('');
    const input = component.getInput();

    //act
    const result = component.add(input);

    //assert

    expect(result).toBe(0);
  });


  it('should return same value if input dont have comma separated values', () => {
    //arrange 
    const input = calculatorSpyObject.getInput.and.returnValue('11');

    //act
    const result = component.add(input);

    //assert
    expect(result).toBe(11);
  });

  it('should return addintion of two', () => {
    //arrange 
    const input = calculatorSpyObject.getInput.and.returnValue('33, 55');

    //act
    const result = component.add(input);

    //assert
    expect(result).toBe(88);

  });

  it('should throw an exception of the input contain more than 2 numbers comma separated', () => {
    //arrange 
    const input = calculatorSpyObject.getInput.and.returnValue('33,55,44');

    //act
    const result = component.add(input);

    //assert
    expect(result).toBe(132);
  });


  it('should return not a number if two non integers and one integer', () => {
    //arrange 
    calculatorSpyObject.getInput.and.returnValue("ggg,vvv,333");

    const input = 
    //act
    let result;
    try {
      result = component.add(input);
    } catch (ex: any) {
      //assert
      expect(ex?.message).toEqual("ggg is not a valid number");
    }
  });

});
