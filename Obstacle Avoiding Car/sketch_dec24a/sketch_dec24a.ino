const int trigPin1 = 7; // Front US sensor reference from back
const int echoPin1 = 6; // Front US sensor reference from back
const int trigPin2 = 12; // Right US sensor reference from back
const int echoPin2 = 13; // Right US sensor reference from back
const int trigPin3 = 9; // Left US sensor reference from back
const int echoPin3 = 8; // Left US sensor reference from back
const int in1 = 2; // Right wheel reference from back
const int in2 = 3; // Right wheel reference from back
const int in3 = 4; // Left wheel reference from back
const int in4 = 5; // Left wheel reference from back

#define DIS 25

void setup()
{
  pinMode(trigPin1, OUTPUT);
  pinMode(echoPin1, INPUT);
  pinMode(trigPin2, OUTPUT);
  pinMode(echoPin2, INPUT);
  pinMode(trigPin3, OUTPUT);
  pinMode(echoPin3, INPUT);
  pinMode (in1, OUTPUT);
  pinMode (in2, OUTPUT);
  pinMode (in3, OUTPUT);
  pinMode (in4, OUTPUT);

  pinMode (10, OUTPUT);
  pinMode (11, OUTPUT);
  
  Serial.begin(9600);
}
void loop()
{
 analogWrite(10, 80);
 analogWrite(11, 80);


 /*
  long Front = FrontSensor();
  long Right = RightSensor();
  long Left = LeftSensor();
  if (Front > DIS && Right > DIS &&  Left> DIS)
  {
    forward();
  }
  else if (Front > DIS && Right < DIS && Left < DIS) // Obstacle on right and Left
  {
    forward();
  }
  else if (Front < DIS && Right < DIS && Left < DIS) // obstacle inFront of all 3 sides
  {
    reverse();
    delay(2000);
    if(LeftSensor() > RightSensor())
    {
      turn_Left();
    }  
    else
    {
      turn_right();
    }
  }
  else if (Front < DIS && Right < DIS && Left> DIS) // obstacle on right and Front sides
  {
    turn_Left (); // turn Left side
  }
  else if (Front < DIS && Right > DIS && Left< DIS) // obstacle on Left and Front sides
  {
    turn_right (); // turn right side
  }
  else if (Front < DIS && Right > DIS && Left > DIS) // obstacle on Front sides
  {
    turn_Left(); 
    delay(1500);
    forward();
  }
  else if (Front > DIS && Right > DIS && Left < DIS) // obstacle on Left sides
  {
    turn_right(); // then turn right and then forward
    delay(1500);
    forward();
  }
  else if (Front > DIS && Right < DIS && Left > DIS) // obstacle on right sides
  {
    turn_Left (); // then turn Left and then right
    delay(1500);
    forward();
  }
  else
  {
    forward();
  }
  
  
  Serial.print("FrontSensor: ");
  Serial.println(FrontSensor());
  Serial.print("RightSensor: ");
  Serial.println(RightSensor());
  
  Serial.print("LeftSensor: ");
  Serial.println(LeftSensor());
  delay(1000);
 
 */
  if (FrontSensor () > DIS && RightSensor () < DIS && LeftSensor () < DIS) // No obstacle at all 
  {
    forward();
  }
  else if (FrontSensor () > DIS && RightSensor () > DIS && LeftSensor () > DIS) // No obstacle at all 
  {
    forward();
  }
  else if (FrontSensor() < DIS && RightSensor () < DIS && LeftSensor () < DIS) // obstacle inFront of all 3 sides
  {
    reverse();
    delay(2000);
    if(LeftSensor() > RightSensor())
    {
      turn_Left();
    }  
    else
    {
      turn_right();
    }
  }
  else if (FrontSensor() < DIS && RightSensor () < DIS && LeftSensor ()> DIS) // obstacle on right and Front sides
  {
    turn_Left (); // turn Left side
  }
  else if (FrontSensor() < DIS && RightSensor () > DIS && LeftSensor ()< DIS) // obstacle on Left and Front sides
  {
    turn_right (); // turn right side
  }
  else if (FrontSensor() < DIS && RightSensor () > DIS && LeftSensor () > DIS) // obstacle on Front sides
  {
    turn_Left(); 
    delay(1500);
    //forward();
  }
  else if (FrontSensor() > DIS && RightSensor () > DIS && LeftSensor () < DIS) // obstacle on Left sides
  {
    turn_right(); // then turn right and then forward
    delay(1500);
    //forward();
  }
  else if (FrontSensor() > DIS && RightSensor () < DIS  && LeftSensor () > DIS) // obstacle on right sides
  {
    turn_Left (); // then turn Left and then right
    delay(1500);
   // forward();
  }
  else
  {
    forward();
  }
  
}
void forward()
{
  digitalWrite(in1, LOW);
  digitalWrite(in2, HIGH);
  digitalWrite(in3, LOW);
  digitalWrite(in4, HIGH);
}
void turn_Left()
{
  digitalWrite(in3, LOW);
  digitalWrite(in4, LOW);
  digitalWrite(in1, LOW);
  digitalWrite(in2, HIGH);
}
void turn_right()
{
  digitalWrite(in1, LOW);
  digitalWrite(in2, LOW);
  digitalWrite(in3, LOW);
  digitalWrite(in4, HIGH);

}
void reverse ()
{
  digitalWrite(in1, HIGH);
  digitalWrite(in2, LOW);
  digitalWrite(in3, HIGH);
  digitalWrite(in4, LOW);

}
void Stop()
{
  digitalWrite(in1, LOW);
  digitalWrite(in2, LOW);
  digitalWrite(in3, LOW);
  digitalWrite(in4, LOW);

}
long FrontSensor ()
{
  long dur;
  digitalWrite(trigPin1, LOW);
  delayMicroseconds(2); // delays are required for a succesful sensor operation.
  digitalWrite(trigPin1, HIGH);
  delayMicroseconds(10); //this delay is required as well!
  digitalWrite(trigPin1, LOW);
  dur = pulseIn(echoPin1, HIGH);
  //return (dur * 0.034 / 2);// convert the distance to centimeters.
  return (dur / 58);
}

long RightSensor ()
{
  long dur;
  digitalWrite(trigPin2, LOW);
  delayMicroseconds(2); // delays are required for a succesful sensor operation.
  digitalWrite(trigPin2, HIGH);
  delayMicroseconds(10); //this delay is required as well!
  digitalWrite(trigPin2, LOW);
  dur = pulseIn(echoPin2, HIGH);
  //return (dur * 0.034 / 2);// convert the distance to centimeters.
  return (dur / 58);// convert the distance to centimeters.
}
long LeftSensor ()
{
  long dur;
  digitalWrite(trigPin3, LOW);
  delayMicroseconds(2); // delays are required for a succesful sensor operation.
  digitalWrite(trigPin3, HIGH);
  delayMicroseconds(10); //this delay is required as well!
  digitalWrite(trigPin3, LOW);
  dur = pulseIn(echoPin3, HIGH);
  //return (dur * 0.034 / 2);// convert the distance to centimeters.
  return (dur / 58);// convert the distance to centimeters.
}
