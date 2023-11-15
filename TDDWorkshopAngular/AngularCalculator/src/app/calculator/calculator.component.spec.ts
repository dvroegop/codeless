import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculatorComponent } from './calculator.component';

describe('CalculatorComponent', () => {
  let component: CalculatorComponent;
  let fixture: ComponentFixture<CalculatorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CalculatorComponent]
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
    const input = "";

    //act
    const result = component.add(input);

    //assert

    expect(result).toBe(0);
  });


  it('should return same value if input dont have comma separated values', () => {
    //arrange 
    const input = "11";

    //act
    const result = component.add(input);

    //assert
    expect(result).toBe(11);
  });

  it('should return addintion of two', () => {
    //arrange 
    const input = "33,55";

    //act
    const result = component.add(input);

    //assert
    expect(result).toBe(88);

  });

  it('should throw an exception of the input contain more than 2 numbers comma separated', () => {
    //arrange 
    const input = "33,55,44";

    //act
    let result;
    try {
      result = component.add(input);
    } catch (ex: any) {
      //assert
      expect(ex?.message).toEqual("Only summing 2 inputs is permitted");
    }
  });


  it('should return not a number if two non integers and one integer', () => {
    //arrange 
    const input = "ggg,vvv,333";

    //act
    let result;
    try {
      result = component.add(input);
    } catch (ex: any) {
      //assert
      expect(ex?.message).toEqual("Only summing 2 inputs is permitted");
    }

  });

});
