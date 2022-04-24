import cv2 as cv
import numpy as np

K = cv.imread('Photos\Female.tif') #Reading the image into K

cv.imwrite('K.png',K)

L = ~K #Giving L the negative value of K
cv.imshow('Negative value' , L)  #Display the image
cv.waitKey(0)

#cv.imwrite('L.png',L) to print the picture to an output

#scealing an image by 2
width = int(K.shape[1] * 2) 
height = int(K.shape[0] * 2)
dimenstions = (width , height)

R = cv.resize(K, dimenstions , interpolation = cv.INTER_NEAREST) #This for the resize process giving the function a interploation as nearest which work as the zeorth-hold formela

#cv.imwrite('R.png', R) to print the picture to an output

cv.imshow('Rescale by 2' ,R) #Display the image
cv.waitKey(0)

