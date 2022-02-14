import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { UserService } from './user.service';

describe('UserService', () => {
  let service: UserService;
  let controller: HttpTestingController;

  beforeEach(() => {
    // TestBed.configureTestingModule({});
    // service = TestBed.inject(UserService);
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [UserService],
    });
    service = TestBed.inject(UserService);
    controller = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    controller.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  fit('#get should return value expected data',
    (done: DoneFn) => {

      const expectedData: any = [
        { 'name': 'one' },
        { 'name': 'two' },
        { 'name': 'three' },
      ];
      service.get().subscribe(data => {
        expect(data).toEqual(expectedData);
        done();
      });
  
      const testRequest = controller.expectOne('https://localhost:5001/api/User');
  
      testRequest.flush(expectedData);    
  });
});
