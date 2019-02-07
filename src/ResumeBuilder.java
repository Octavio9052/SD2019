import java.beans.XMLEncoder;
import java.io.BufferedOutputStream;
import java.io.FileOutputStream;
import java.util.*;

public class ResumeBuilder {
  private Scanner keyboard = new Scanner(System.in);

  public void run(){
    buildResume();
  }

  private void buildResume(){
    Resume resume = new Resume();
    ArrayList<Employment> jobs = new ArrayList<>();
    String[] fieldNames = {"full name","email","cellphone","photoUri","birthplace"};
    resume.setFullName(requestField(fieldNames[0]));
    resume.setEmail(requestField(fieldNames[1]));
    resume.setCellphone(requestField(fieldNames[2]));
    resume.setPhotoUri(requestField(fieldNames[3]));
    resume.setBirthplace(requestField(fieldNames[4]));
    resume.setAddress(requestAddress());
    System.out.println("Input new employment? Y/n");

    while (keyboard.nextLine().toUpperCase().equals("Y")){
      jobs.add(requestEmployment());
      System.out.println("Input new employment? Y/n");
    }

    resume.setJobs(jobs);
    System.out.println(resume);
  }

  private Employment requestEmployment() {
    String[] fields = {"start date (dd-mm-yyyy)", "end date (dd-mm-yyyy)", "company", "job role"};

    for(int i= 0; i < fields.length; i++){
      fields[i] = requestField(fields[i]);
    }

    return new Employment(fields[0], fields[1], fields[2], fields[3]);
  }

  private Address requestAddress(){
    String[] fields = {"street", "outside number", "county", "city"};
    for(int i= 0; i < fields.length; i++){
      fields[i] = requestField(fields[i]);
    }
    return new Address(fields[0], fields[1], fields[2], fields[3]);
  }

  private String requestField(String fieldName){
    System.out.println("Enter " + fieldName);
    return keyboard.nextLine();
  }
}
