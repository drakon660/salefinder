package com.salefinder;

import java.io.File;

public class Main {

    public static void main(String[] args)
    {
        try {

            //PDFProcessor processor = new PDFProcessor("d:/carrefour.pdf");
            //String text = processor.readTextFromPage(1);
            File.createTempFile("PDFBox", ".tmp", new File("d:/"));
            PDFBoxServer server = new PDFBoxServer();
            server.start();
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
}
