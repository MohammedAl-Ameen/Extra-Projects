import cv2 as cv
import matplotlib.pyplot as plt
import numpy as np

I = cv.imread('Photos\lena.jpg') #Reading an image into I

#cv.imwrite('I.png', I) to print the picture to an output

#Splitting the image into four components
I1 = I[0:I.shape[1]//2 ,0:I.shape[1]//2] 
I2 = I[0:I.shape[1]//2,I.shape[1]//2:I.shape[1]]
I3 = I[I.shape[1]//2:I.shape[1],0:I.shape[1]//2]
I4 = I[I.shape[1]//2:I.shape[1],I.shape[1]//2:I.shape[1]]

J = np.zeros((512,512,3), dtype = np.uint8) #defining an 512*512 image into J 

#putting the four components into J as in part b
J[0:J.shape[1]//2,0:256] = I4
J[0:J.shape[1]//2,J.shape[1]//2:J.shape[1]] = I3
J[J.shape[1]//2:J.shape[1],0:J.shape[1]//2] = I2
J[J.shape[1]//2:J.shape[1],J.shape[1]//2:J.shape[1]] = I1

#cv.imwrite('J.png', J) to print the picture to an output

#Displaying the image
plt.imshow(J)
plt.show()


#Displaying the Histograms for both pictures 
plt.hist(I.ravel() , bins = 255)
plt.show()

plt.hist(J.ravel() , bins = 255)
plt.show()