################################################################################################
################            CODIGO DE PYTHON PARA GRAFICAR LAS PRUEBAS          ################
################                DE CONTROL, TECLADO Y lEAP MOTION               ################
################            EN LA TESIS DE RUBEN PAREDES, ASESORADO POR         ################
################                    M.A. LUIS YAIR BAUTISTA BLANCO              ################
################################################################################################

#Import required libraries
import os
from tkinter.filedialog import test
import pandas as pd
import numpy as np
from openpyxl.workbook import Workbook

import matplotlib.pyplot as plt
import datetime
#import seaborn as sns

#Constants required
CurrentDirectory = os.path.dirname(os.path.abspath(__file__))
DataFileName = "Position Data.xlsx"

#################################
######### Funciones #############
#################################

# Reads an excel sheet
def read_excel(CurrentDirectory, DataFileName):
    DataFile = pd.ExcelFile (DataFileName)
    sheets = DataFile.book.worksheets
    testNumber = 1    
    previousN = 1
    LML = 0
    lml = 0
    
    DL = pd.DataFrame({'A': []})
    for sheet in sheets:
        #No lee las hojas de excel ocultas
        if(sheet.sheet_state != 'visible'):
            continue
        #Nombre de la prueba    
        testName = sheet.title
        #Del nombre de la prueba extraigo el numero y lo comparo, si es menor igual a 20 guardare la informacion de la prueba pasada
        testNumber = testName.replace('Prueba ','').replace('LEAP','').replace('Teclado','').replace('Control','')
        testNumber = int(testNumber)
        #Si hay un cambio en el numero de prueba. grafica el XvsY
        if(previousN != testNumber):
            #grafica_KvsC(testNumber-1, DT, DC, DL)
            #grafica_1Kvs1C_Blue(testNumber-1, DT, DC, DL)
            grafica_1Kvs1C_Blue_X(testNumber-1, DT, DC, DL, LMT, LMC, LML, lmt, lmc, lml)
            grafica_1Kvs1C_Blue_Y(testNumber-1, DT, DC, DL)
            #grafica_1Kvs1C_Green(testNumber-1, DT, DC, DL)
        if(testNumber == 26):
            return()
        #Obtiene la data en Excel
        dataTest = pd.read_excel(DataFile, sheet.title, names=['Time', 'T_Blue', 'X_Blue', 'Y_Blue', 'T_Green','X_Green','Y_Green', 'T_Orange','X_Orange','Y_Orange', 'T_Red','X_Red','Y_Red'], usecols=range(13), skiprows = 2)
        #Rellena la data faltante con interpolacion
        dT = dataTest.interpolate(method = "linear")
        # Grafica
        #grafica_PvsT(testNawame, dT)          #Posicion X & Y vs Tiempo 
        #grafica_XvsY(testName, dT)          #Posicion X vs Y        
        
        # Guarda la información
        if("Teclado" in testName):
            DT=dT
            LMT = DT['X_Blue'].max()
            lmt = DT['X_Blue'].min()
            YLMT = DT['Y_Blue'].max()
            print(testName, YLMT)
            #print(testLMT)
        
        if("Control" in testName):
            DC=dT
            LMC = DC['X_Blue'].max()
            lmc = DC['X_Blue'].min()
            YLMC = DC['Y_Blue'].max()

            print(testName, YLMC)
            #print(LMC)
            
        if("LEAP" in testName):
            DL=dT
            LML = DL['X_Blue'].max()
            lml = DL['X_Blue'].min()
            YLML = DL['Y_Blue'].max()

            print(testName, YLML)
            #print(LML)
        
        
        
        previousN = testNumber
    
    return()
        

def grafica_PvsT(testName, dT):
    plt.style.use('seaborn-v0_8-dark-palette')
    plt.plot(dT['T_Blue'], dT['X_Blue'], label = "Disco Azul X", c = 'b')
    plt.plot(dT['T_Green'], dT['X_Green'], label = "Disco Verde X", c = 'g' )
    plt.plot(dT['T_Orange'], dT['X_Orange'], label = "Disco Naranja X", c = '#FF8000' )
    plt.plot(dT['T_Red'], dT['X_Red'], label = "Disco Rojo X", c = 'r')
    plt.xlabel('Tiempo (s)', fontsize = 10)
    plt.ylabel('Posicion X (cm)', fontsize = 10)
    #plt.xlim(left = 1, right = 40)
    plt.ylim(bottom=-40, top =40)
    plt.title(testName + " X", fontsize = 20)
    plt.savefig("PvsT/"+testName+" X"+".png")
    plt.close()
    
    
    plt.style.use('seaborn-v0_8-dark-palette')
    plt.plot(dT['T_Blue'], dT['Y_Blue'], label = "Disco Azul Y", c = 'b')
    plt.plot(dT['T_Green'], dT['Y_Green'], label = "Disco Verde Y", c = 'g' )
    plt.plot(dT['T_Orange'], dT['Y_Orange'], label = "Disco Naranja Y", c = '#FF8000' )
    plt.plot(dT['T_Red'], dT['Y_Red'], label = "Disco Rojo Y", c = 'r')
    plt.xlabel('Tiempo (s)', fontsize = 10)
    plt.ylabel('Posicion Y (cm)', fontsize = 10)
    #plt.xlim(left = 1, right = 40)
    #plt.ylim(bottom=0, top =45)
    plt.title(testName + " Y", fontsize = 20)
    plt.savefig("PvsT/"+testName+" Y"+".png")
    plt.close()        
        
def grafica_XvsY(testName, dT):
    plt.style.use('seabornv0_8-dark-palette')
    plt.plot(dT['X_Blue'], dT['Y_Blue'], label = "Disco Azul X", c = 'b')
    plt.plot(dT['X_Green'], dT['Y_Green'], label = "Disco Verde X", c = 'g' )
    plt.plot(dT['X_Orange'], dT['Y_Orange'], label = "Disco Naranja X", c = '#FF8000' )
    plt.plot(dT['X_Red'], dT['Y_Red'], label = "Disco Rojo X", c = 'r')
    plt.xlabel('Posicion X (cm)', fontsize = 10)
    plt.ylabel('Posicion Y (cm)', fontsize = 10)
    #plt.xlim(left = 1, right = 40)
    #plt.ylim(bottom=-40, top =40)
    plt.title(testName + " XvsY", fontsize = 20)
    plt.savefig("XvsY/"+testName+" XvsY"+".png")
    plt.close()

def grafica_KvsC(testNumber, DT, DC, DL):
    plt.style.use('seaborn-v0_8-dark-palette')
    newname = "KvsC"
    #Teclado
    plt.plot(DT['T_Blue'], DT['X_Blue'], label = "Disco Azul X", c = '#00BFFF')
    plt.plot(DT['T_Green'], DT['X_Green'], label = "Disco Verde X", c = '#A4DE00' )
    plt.plot(DT['T_Orange'], DT['X_Orange'], label = "Disco Naranja X", c = '#DAA900' )
    plt.plot(DT['T_Red'], DT['X_Red'], label = "Disco Rojo X", c = '#FB5958')
    #Control
    plt.plot(DC['T_Blue'], DC['X_Blue'], label = "Disco Azul X", c = 'b')
    plt.plot(DC['T_Green'], DC['X_Green'], label = "Disco Verde X", c = 'g' )
    plt.plot(DC['T_Orange'], DC['X_Orange'], label = "Disco Naranja X", c = '#FF8000' )
    plt.plot(DC['T_Red'], DC['X_Red'], label = "Disco Rojo X", c = 'r')
    
    if(DL.empty == False):
        #LEAP
        plt.plot(DL['T_Blue'], DL['X_Blue'], label = "Disco Azul X", c = '#99CCFF')
        plt.plot(DL['T_Green'], DL['X_Green'], label = "Disco Verde X", c = '#99FF99' )
        plt.plot(DL['T_Orange'], DL['X_Orange'], label = "Disco Naranja X", c = '#FFCC99' )
        plt.plot(DL['T_Red'], DL['X_Red'], label = "Disco Rojo X", c = '#FF99CC')
        newname = "KvsCvsL"
    
    plt.xlabel('Tiempo (s)', fontsize = 10)
    plt.ylabel('Posicion X (cm)', fontsize = 10)
    #plt.xlim(left = 1, right = 40)
    plt.ylim(bottom=-40, top =40)
    plt.title("Prueba" + str(testNumber) + " X", fontsize = 20)
    plt.savefig("KvsC/"+ "Prueba "+ str(testNumber) +" " + newname +" X"+".png")
    plt.close()
    
    plt.style.use('seaborn-v0_8-dark-palette')
    newname = "KvsC"
    #Teclado
    plt.plot(DT['T_Blue'], DT['Y_Blue'], label = "Disco Azul Y", c = '#00CFFF')
    plt.plot(DT['T_Green'], DT['Y_Green'], label = "Disco Verde Y", c = '#A4DE00' )
    plt.plot(DT['T_Orange'], DT['Y_Orange'], label = "Disco Naranja Y", c = '#DAA900' )
    plt.plot(DT['T_Red'], DT['Y_Red'], label = "Disco Rojo Y", c = '#FB5958')
    #Control
    plt.plot(DC['T_Blue'], DC['Y_Blue'], label = "Disco Azul Y", c = 'b')
    plt.plot(DC['T_Green'], DC['Y_Green'], label = "Disco Verde Y", c = 'g' )
    plt.plot(DC['T_Orange'], DC['Y_Orange'], label = "Disco Naranja Y", c = '#FF8000' )
    plt.plot(DC['T_Red'], DC['Y_Red'], label = "Disco Rojo Y", c = 'r')
    
    if(DL.empty == False):
        #LEAP
        plt.plot(DL['T_Blue'], DL['Y_Blue'], label = "Disco Azul X", c = '#99CCFF')
        plt.plot(DL['T_Green'], DL['Y_Green'], label = "Disco Verde X", c = '#99FF99' )
        plt.plot(DL['T_Orange'], DL['Y_Orange'], label = "Disco Naranja X", c = '#FFCC99' )
        plt.plot(DL['T_Red'], DL['Y_Red'], label = "Disco Rojo X", c = '#FF99CC')
        newname = "KvsCvsL"
    
    
    plt.xlabel('Tiempo (s)', fontsize = 10)
    plt.ylabel('Posicion Y (cm)', fontsize = 10)
    #plt.xlim(left = 1, right = 40)
    #plt.ylim(bottom=0, top =45)
    plt.title("Prueba" + str(testNumber) + " Y", fontsize = 20)
    plt.savefig("KvsC/"+"Prueba " + str(testNumber) + " "+ newname +" Y"+".png")
    plt.close()

def grafica_1Kvs1C_Blue_X(testNumber, DT, DC, DL, LMT, LMC, LML, lmt, lmc, lml):
    plt.style.use('seaborn-v0_8-dark-palette')
    newname = "KvsC Blue"
    #Teclado
    plt.plot(DT['T_Blue'], DT['X_Blue'], label = "Teclado Azul X", c = '#3333FF')
    plt.plot(DT['T_Blue'], [f1(LMT) for i in DT['T_Blue']], c='#3333FF', ls = ':')
    plt.plot(DT['T_Blue'], [f1(lmt) for i in DT['T_Blue']], c='#3333FF', ls = ':')
    #Control
    plt.plot(DC['T_Blue'], DC['X_Blue'], label = "Control Azul X", c = '#3399FF')
    plt.plot(DC['T_Blue'], [f1(LMC) for i in DC['T_Blue']], c='#3399FF', ls = ':')
    plt.plot(DC['T_Blue'], [f1(lmc) for i in DC['T_Blue']], c='#3399FF', ls = ':')
    
    if(DL.empty == False):
        #LEAP
        plt.plot(DL['T_Blue'], DL['X_Blue'], label = "Leap Azul X", c = '#33FFFF')
        plt.plot(DL['T_Blue'], [f1(LML) for i in DL['T_Blue']], c='#33FFFF', ls = ':')
        plt.plot(DL['T_Blue'], [f1(lml) for i in DL['T_Blue']], c='#33FFFF', ls = ':')
        newname = "KvsCvsL Blue"
    plt.xlabel('Tiempo (s)', fontsize = 10)
    plt.ylabel('Posicion X (cm)', fontsize = 10)
    #plt.xlim(left = 1, right = 40)
    plt.ylim(bottom=-50, top =50)
    plt.legend(loc = 'lower center')
    plt.title("Prueba" + str(testNumber) + " X", fontsize = 20)
    plt.savefig("1Kvs1Cvs1L Blue/"+ "Prueba "+ str(testNumber) +" " + newname +" X"+".png", dpi=400)
    plt.close()
    
def grafica_1Kvs1C_Green(testNumber, DT, DC, DL):
    plt.style.use('seaborn-v0_8-dark-palette')
    newname = "KvsC Green"
    #Teclado
    plt.plot(DT['T_Green'], DT['X_Green'], label = "Disco Verde X", c = '#A4DE00')
    #plt.plot(DT['T_Green'], DT.max(axis = 1), c='#CFE495')
    #Control
    plt.plot(DC['T_Green'], DC['X_Green'], label = "Disco Verde X", c = 'g')
    if(DL.empty == False):
        #LEAP
        plt.plot(DL['T_Green'], DL['X_Green'], label = "Disco Verde X", c = '#99CCFF')
        newname = "KvsCvsL Green"
    plt.xlabel('Tiempo (s)', fontsize = 10)
    plt.ylabel('Posicion X (cm)', fontsize = 10)
    #plt.xlim(left = 1, right = 40)
    plt.ylim(bottom=-45, top =45)
    plt.title("Prueba" + str(testNumber) + " X", fontsize = 20)
    plt.savefig("1Kvs1Cvs1L Green/"+ "Prueba "+ str(testNumber) +" " + newname +" X"+".png")
    plt.close()

def grafica_1Kvs1C_Blue_Y(testNumber, DT, DC, DL):
    plt.style.use('seaborn-v0_8-dark-palette')
    newname = "KvsC Blue"
    #Teclado
    plt.plot(DT['T_Blue'], DT['Y_Blue'], label = "Teclado Azul Y", c = '#3333FF')
    #Control
    plt.plot(DC['T_Blue'], DC['Y_Blue'], label = "Control Azul Y", c = '#3399FF')
    if(DL.empty == False):
        #LEAP
        plt.plot(DL['T_Blue'], DL['Y_Blue'], label = "Leap Azul Y", c = '#33FFFF')
        newname = "KvsCvsL Blue"
    plt.xlabel('Tiempo (s)', fontsize = 10)
    plt.ylabel('Posicion X (cm)', fontsize = 10)
    #plt.xlim(left = 1, right = 40)
    plt.ylim(bottom=0, top =40)
    plt.legend(loc = 'lower center')
    plt.title("Prueba" + str(testNumber) + " X", fontsize = 20)
    plt.savefig("1Kvs1Cvs1L Blue/"+ "Prueba "+ str(testNumber) +" " + newname +" Y"+".png",  dpi=400)
    plt.close()

#Funciones lineales
def f1(c):
    c1 = 1
    return c*c1 

       
#################################
### Programa principal
#################################
if __name__ == '__main__':
    read_excel(CurrentDirectory, DataFileName)
    
    

