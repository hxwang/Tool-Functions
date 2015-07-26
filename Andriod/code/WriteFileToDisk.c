package com.example.splitcpuio;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;
import java.util.Random;

import android.graphics.Bitmap;
import android.os.Environment;
import android.util.Log;


public class WriteFileToDisk {
	
	private static final int BUFFER_SIZE = 8192000;
	private static char[] buf;
	
	static
	{
		buf = new char[BUFFER_SIZE];
		
		for(int i=0;i<BUFFER_SIZE;i++)
		{
			buf[i] = (char)(i % 128);
		}
	}
	
	public static void ReadWriteFile(int upperBound) throws IOException
	{
		
		
		String writefilePath = "/sdcard/Pictures/Screenshots/newimage.png";
		
		BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(writefilePath)));
		
		while(upperBound>0)
		{
			
			bw.write(buf, 0, BUFFER_SIZE);
					
			bw.flush();
			
		    upperBound = upperBound -1;
		}
		
		bw.close();
	}
	


}
