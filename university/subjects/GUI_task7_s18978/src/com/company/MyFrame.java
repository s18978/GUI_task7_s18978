package com.company;

import javax.swing.*;
import java.awt.*;
import java.util.ArrayList;
import java.util.Arrays;

public class MyFrame extends JFrame{

    public MyFrame()
    {
        //        JFrame frame = new JFrame("text");
//        frame.setVisible(true);
//        frame.setSize(new Dimension(600,400));
//        frame.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);

        super("Task 7");
        setVisible(true);
        //setSize(new Dimension(600,400));
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        ArrayList<Integer> list = new ArrayList<>();
        list.add(412345);
        list.add(600000);
        list.add(254321);
        list.add(100000);
        setContentPane(new MyButton("Rotate",list));
        pack();



    }





    public static void main(String[] args) {
        SwingUtilities.invokeLater(MyFrame::new);
    }

}
