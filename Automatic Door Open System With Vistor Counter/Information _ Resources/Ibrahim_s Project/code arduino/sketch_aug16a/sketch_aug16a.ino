#include <Servo.h>
#include <Keypad.h>
#include <LiquidCrystal.h>

LiquidCrystal lcd(A4, A5, A3, A2, A1, A0);
Servo myservo;
const byte rows=4;
const byte cols=3;
byte rowPins[rows]={0,1,2,3};
byte colPins[cols]={4,5,6}; 
char key[rows][cols]={{'1','2','3'},{'4','5','6'},{'7','8','9'},{'*','0','#'}};
Keypad keypad= Keypad(makeKeymap(key),rowPins,colPins,rows,cols);

 char* passnumber="88776655";
 int red=7;
 int green=8;
 
 int Bit=0;
 int pos=0;
 int flage=0;
 int counter=0;
 
void setup()
{
 myservo.attach(9);
 pinMode(red,OUTPUT);
 pinMode(green,OUTPUT);
 lcd.begin(16,2);
}
 
void loop()
{
if( Bit==0)
{
 myservo.write(pos);
 lcd.setCursor(0,0);
 lcd.println(" PLEASE ENTER ");
 lcd.setCursor(0 ,1);
 lcd.println("   THE PASSWORD : "); 
}

char password=keypad.getKey();
if(password!=NO_KEY)
{ 
lcd.clear();
lcd.setCursor(2,0);
lcd.print("PASSWORD:");
lcd.setCursor(0,1);
for(int i=0;i<= Bit ;++i)
lcd.print(" *");

  if (password!=passnumber[Bit])
      flage=1;
  ++Bit;
  if((Bit==8)&&(flage==0))
    unlockdoor();
   if((Bit==8)&&(flage==1))
  lockdoor();
   if (counter ==3)
    blocked_for_10_sec ();
    }}


void unlockdoor()
{
  digitalWrite(green,HIGH);
  digitalWrite(red,LOW);
  lcd.clear();
  lcd.setCursor(1,0);
  lcd.print("unlock the door");
  pos=120;
  myservo.write(pos); 
  delay(1000);
  pos=0;
  Bit=0;
  
  lcd.setCursor(4,1);
  lcd.print("5");
  delay(1000);
  lcd.setCursor(4,1);
  lcd.print("4");
  delay(1000);
  lcd.setCursor(4,1); 
  lcd.print("3");
  delay(1000);
  lcd.setCursor(4,1); 
  lcd.print("2");
  delay(1000);
  lcd.setCursor(4,1);
  lcd.print("1");
  delay(1000);
  
  lcd.clear();
  lcd.setCursor(2,0);
  lcd.print(" LOCKED ..");
  delay(1000);
  myservo.write(pos);
  digitalWrite(green,LOW);
  digitalWrite(red,HIGH);
  delay(1000);
  digitalWrite(red,LOW);
  }

 void lockdoor()
 {
 digitalWrite(green,LOW);
 digitalWrite(red,HIGH);  
 
 lcd.clear();
 lcd.setCursor(1,0);
 lcd.print("INCORRECT ");
 lcd.setCursor(5,1);
 lcd.print(" PASSWORD ");
 
 myservo.write(pos);
 delay(1000);
 lcd.clear();
 counter ++;
 flage=0;
 Bit=0;
 digitalWrite(green,LOW);
 digitalWrite(red,LOW);
 }
 
 void blocked_for_10_sec ()
  {
    counter =0;
    digitalWrite(green,LOW);
    digitalWrite(red,HIGH);  
    lcd.clear();
    
    lcd.setCursor(0,0);
    lcd.print("3 times of");
    lcd.setCursor(0,1);
    lcd.print("invalid password");
    lcd.setCursor(0,1);
    delay(1000);
    lcd.clear();
    lcd.setCursor(0,0);
    lcd.print("you are blocked");
    lcd.setCursor(0,1);
    lcd.print("for 10 sec ");
    lcd.setCursor(0,1);
    delay(1000);
    lcd.clear();
    lcd.setCursor(0,0);
    lcd.print("please wait ");
    lcd.setCursor(0,1);
    lcd.print("and try again ");
    lcd.setCursor(0,1);
    delay(1000);
    lcd.clear();
    lcd.setCursor(0,0);
    lcd.print("please wait");
    
    lcd.setCursor(4,1); 
    lcd.print("9");
    delay(1000);
    lcd.setCursor(4,1);
    lcd.print("8");
    delay(1000);
    lcd.setCursor(4,1); 
    lcd.print("7");
    delay(1000);
    lcd.setCursor(4,1); 
    lcd.print("6");
    delay(1000);
    lcd.setCursor(4,1);
    lcd.print("5");
    delay(1000);
    lcd.setCursor(4,1);
    lcd.print("4");
    delay(1000);
    lcd.setCursor(4,1);
    lcd.print("3");
    delay(1000);
    lcd.setCursor(4,1); 
    lcd.print("2");
    delay(1000);
    lcd.setCursor(4,1); 
    lcd.print("1");
    delay(1000);
    lcd.setCursor(4,1);
    lcd.print("0");
    delay(1000);
    lcd.clear();

    digitalWrite(green,LOW);
    digitalWrite(red,LOW);  
 }
