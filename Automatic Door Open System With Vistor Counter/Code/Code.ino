// Frequency is assumed to be 16MHz to achieve 1s delay in opening or closing the door.

#include <LiquidCrystal.h>
LiquidCrystal lcd(13, 12, 11, 10, 9, 8);

#define PIR_sensor 14 // The pin A0 is treated is a digital.
#define IN2 0 // Used for the H-Bridge to control the direction of the DC motor.
#define IN1 1 // Used for the H-Bridge to control the direction of the DC motor.
#define redLED 5 // Door is closed
#define yellowLED 6 // Door is opening or closing
#define greenLED 7 // Door is opened
#define buzzer 4 // Makes a sound when the door is opened or closed

int visits = 0;

void setup()
{
   /*Used to initilize the LCD*/
  lcd.begin(20, 4);
  lcd.clear();
  
  /*Used to initilize the ports*/
  pinMode(redLED, OUTPUT);
  pinMode(yellowLED, OUTPUT);
  pinMode(greenLED, OUTPUT); 
  pinMode(buzzer, OUTPUT); 
  pinMode(IN2, OUTPUT);
  pinMode(IN1, OUTPUT);
  pinMode(PIR_sensor, INPUT);
  
  lcd.setCursor(0,0); // (Column, row) --> Starts at (0,0)
  lcd.print("INTELLEGENT DOOR"); 
}
void buzz()
{
    digitalWrite(buzzer, HIGH);
    delay(30);
    digitalWrite(buzzer, LOW);  
}
void opening()
{
    lcd.setCursor(0, 1);
    lcd.print("Movement Detected");
    lcd.setCursor(0, 2);
    lcd.print("Gate Opening!");
    digitalWrite(IN2, HIGH);         
    digitalWrite(IN1, LOW);
    digitalWrite(redLED, LOW);
    digitalWrite(greenLED, LOW);
    digitalWrite(yellowLED, HIGH);   
    delay(1000); // It takes 1 second to open the door
    
    digitalWrite(IN2, LOW);       
    digitalWrite(IN1, LOW);   
    lcd.setCursor(0, 2);
    lcd.print("Gate Opened! ");
    buzz(); // Makes a sound when the door is opened
    lcd.setCursor(0, 3);
    lcd.print("Number of visits: ");
    lcd.print(visits);
    digitalWrite(redLED, LOW);
    digitalWrite(greenLED, HIGH);
    digitalWrite(yellowLED, LOW);
}
void closing()
{
    lcd.setCursor(0, 2);
    lcd.print("Gate Closing!"); 
    digitalWrite(IN2, LOW);           
    digitalWrite(IN1, HIGH);
    digitalWrite(redLED, LOW);
    digitalWrite(greenLED, LOW);
    digitalWrite(yellowLED, HIGH);
    delay(1000); // It takes 1 second to close the door
    
    digitalWrite(IN2, LOW);            
    digitalWrite(IN1, LOW);
    lcd.setCursor(0, 2);
    lcd.print("Gate Closed! "); 
    buzz(); // Makes a sound when the door is opened
    digitalWrite(redLED, HIGH);
    digitalWrite(greenLED, LOW);
    digitalWrite(yellowLED, LOW);
}
void loop()
{
  if(digitalRead(PIR_sensor))
  {
    visits++;
    opening();  
    while(digitalRead(PIR_sensor)){} // As long as the door is opened.
    closing();
  }
  else
  {
    lcd.setCursor(0,1);
    lcd.print("No Movement       ");
    lcd.setCursor(0,2);
    lcd.print("Gate Closed");
    digitalWrite(redLED, HIGH);
    digitalWrite(greenLED, LOW);
    digitalWrite(yellowLED, LOW);
  }
}
