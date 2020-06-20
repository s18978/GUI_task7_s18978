package com.company;

import javax.swing.*;
import java.awt.*;
import java.util.ArrayList;

public class MyButton extends JButton {

    private ArrayList<Integer> data;
    private double count;
    private String message;

    private final int START_ANGLE = 90;


    public MyButton(String msg, ArrayList<Integer> list)
    {
        setPreferredSize(new Dimension(500,500));
        //JButton button = new JButton(msg);
        data = list;

        for (Integer i: data) {
            count += i;
        }
        message = msg;

        addActionListener(e ->
        {
            data.add(0,data.get(data.size()-1));
            data.remove(data.size()-1);
        });

    }



    public void paintComponent(Graphics g)
    {
        super.paintComponent(g);

        int width = getWidth()*2/3, height = getHeight()*2/3;
        int centerX = getWidth()/2-width/2,centerY = getHeight()/2 - height/2;

        int sum = 0;
        int alpha = START_ANGLE;
        for (int i = 0; i < data.size(); i++) {

            double percent = data.get(i) * 100./count;
            if (i == data.size()-1) percent = 100-sum;
            double angle = 360. * percent/ 100.;
            sum += percent;

            if(i != 0) {
                g.setColor(new Color((int) (Math.random() * 255), (int) (Math.random() * 255), (int) (Math.random() * 255)));
                g.fillArc(centerX, centerY, width, height, alpha - (int) angle, (int) angle);
            }
            alpha-=angle;
            if(angle - (int)angle > 0)
                alpha ++;

        }
        double percent = data.get(0) * 100./count;
        double angle = 360. * percent/ 100.;
        g.setColor(new Color((int) (Math.random() * 255), (int) (Math.random() * 255), (int) (Math.random() * 255)));
        g.fillArc(centerX, centerY, width, height, 90 - (int) angle, (int) angle);

        g.setColor(Color.black);
        g.drawOval(centerX,centerY,width,height);

        g.setColor(Color.black);
        g.setFont(new Font("consolas",Font.BOLD,50));
        g.drawString(message,centerX - 25,centerY - 25);


    }


}
