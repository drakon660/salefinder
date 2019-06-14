package com.salefinder;

import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.PDPageTree;
import org.apache.pdfbox.text.PDFTextStripper;
import org.apache.pdfbox.text.TextPosition;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class PDFProcessor extends PDFTextStripper {

    private String _fileName;


    public PDFProcessor(String fileName) throws IOException {
        _fileName = fileName;
        File file = new File(fileName);
        document = PDDocument.load(file);
    }

    public int pageCount()
    {
        return document.getNumberOfPages();
    }

    public void closeDocument() throws IOException
    {
        document.close();
    }

    /*
    public void readAllText(String fileName) throws IOException
    {
        File file = new File(fileName);
        document = PDDocument.load(file);
        for (int i=0; i<document.getNumberOfPages(); i++) {

            int pageNr = i+1;
            this.setStartPage(pageNr);
            this.setEndPage(pageNr);

            String text = this.getText(document);
            try (PrintStream out = new PrintStream(new FileOutputStream(fileName + "_" + pageNr + ".txt"))) {
                out.print(text);
            }
        }

        return text;
        //document.close();
    }*/

    public String readTextFromPage(int pageNr) throws IOException
    {
        //File file = new File(_fileName);
        //document = PDDocument.load(file);
        //for (int i=0; i<document.getNumberOfPages(); i++) {

            //int pageNr = i+1;
            this.setStartPage(pageNr);
            this.setEndPage(pageNr);

            String text = this.getText(document);

        //}

        //document.close();
        return text;
    }

    public void stripPage(int pageNr) throws IOException
    {
        this.setStartPage(pageNr+1);
        this.setEndPage(pageNr+1);
        Writer dummy = new OutputStreamWriter(new ByteArrayOutputStream());
        writeText(document,dummy); // This call starts the parsing process and calls writeString repeatedly.

    }

    /*@Override
    protected void writeString(String string,List<TextPosition> textPositions) throws IOException
    {
        for (TextPosition text : textPositions) {

            System.out.println("String[" + text.getXDirAdj()+","+text.getYDirAdj()+" fs="+text.getFontSizeInPt()+" xscale="+text.getXScale()+" height="+text.getHeightDir()+" space="+text.getWidthOfSpace()+" width="+text.getWidthDirAdj()+" ] "+text.getUnicode());
        }
    }*/
}