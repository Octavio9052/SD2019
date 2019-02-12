package com.distribuido.hw.cetys;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import java.io.File;
import java.io.IOException;
import java.time.LocalDate;
import java.time.ZoneId;
import java.time.format.DateTimeFormatter;
import java.util.*;

 public class ResumeBuilder {
  private Scanner keyboard = new Scanner(System.in);
  private static final String RESUME_XML = "C:\\Users\\Octavio\\Desktop\\resumeJava.xml";

  public void run(){
    try{
      doSerialize(buildResume());
    } catch (Exception e){
      System.out.println("Error " + e);
    }
  }

  public void doSerialize(Resume resume) throws JAXBException, IOException {
    JAXBContext context = JAXBContext.newInstance(Resume.class);
    Marshaller m = context.createMarshaller();
    m.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
    m.setProperty("com.sun.xml.internal.bind.xmlHeaders",
            "\n<!DOCTYPE Resume SYSTEM  \"Resume.dtd\">");
    m.marshal(resume, new File(RESUME_XML));
  }

  private Resume buildResume(){
    Resume resume = new Resume();
    ArrayList<Employment> jobs = new ArrayList<>();
    String[] fieldNames = {"full name",
                            "email",
                            "type of email: \t P - Personal \t W - Work \t O - Other",
                            "cellphone",
                            "photoUri",
                            "birthplace"};
    resume.setFullName(requestField(fieldNames[0]));
    resume.setEmail(new Email(requestField(fieldNames[1]), requestTypeOfEmail(fieldNames[2])));
    resume.setCellphone(requestField(fieldNames[3]));
    resume.setPhotoUri(requestField(fieldNames[4]));
    resume.setBirthplace(requestField(fieldNames[5]));
    resume.setAddress(requestAddress());
    System.out.println("Input employment");
    do {
      jobs.add(requestEmployment());
      System.out.println("Input new employment? Y/n");
    } while (keyboard.nextLine().toUpperCase().equals("Y"));

    resume.setJobs(jobs);
    System.out.println(resume);
    return resume;
  }

  private EmailType requestTypeOfEmail(String text){
    switch(requestField(text).charAt(0)){
      case 'P':
        return EmailType.PERSONAL;
      case 'W':
        return EmailType.WORK;
      case 'O':
        return EmailType.OTHER;
        default:
          requestTypeOfEmail("type of email: \t P - Personal \t W - Work \t O - Other");
    }
    return null;
  }

  private Employment requestEmployment() {
    String[] fields = {"start date (yyyy MM dd)", "end date (yyyy MM dd)", "company", "job role"};
    Date[] dates = {new Date(), new Date()};

    dates[0] = requestDate(fields[0]);
    dates[1] = requestDate(fields[1]);
    fields[2] = requestField(fields[2]);
    fields[3] = requestField(fields[3]);

    return new Employment(dates[0], dates[1], fields[2], fields[3]);
  }

  private Address requestAddress(){
    String[] fields = {"street", "outside number", "county", "city"};
    for(int i= 0; i < fields.length; i++){
      fields[i] = requestField(fields[i]);
    }
    return new Address(fields[0], fields[1], fields[2], fields[3]);
  }

  private Date requestDate(String date){
    DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy MM dd");
    LocalDate parsedDate = LocalDate.parse(requestField(date), formatter);
    Date dateTime = Date.from(parsedDate.atStartOfDay(ZoneId.systemDefault()).toInstant());
    return dateTime;
  }

  private String requestField(String fieldName){
    System.out.println("Enter " + fieldName);
    return keyboard.nextLine();
  }
}
