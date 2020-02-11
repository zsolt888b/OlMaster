import { TestBed, inject } from '@angular/core/testing';

import { OlympicService } from './olympic.service';

describe('OlympicService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OlympicService]
    });
  });

  it('should be created', inject([OlympicService], (service: OlympicService) => {
    expect(service).toBeTruthy();
  }));
});
