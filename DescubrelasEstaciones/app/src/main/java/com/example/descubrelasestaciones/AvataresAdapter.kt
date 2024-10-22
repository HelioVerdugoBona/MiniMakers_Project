package com.example.descubrelasestaciones

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import android.widget.ImageView

class AvataresAdapter(context: Context, val layout: Int, val avatares: MutableList<Avatar> ):
ArrayAdapter<Avatar>(context, layout, avatares)
{
    override fun getView(position: Int, convertView: View?, parent: ViewGroup): View {

        val view: View

        if( convertView != null)
        {
            view = convertView
        }else{
            view = LayoutInflater.from((context)).inflate(layout, parent,false)
        }

        bindAvatar(view, avatares[position])
        return view
    }

    private fun bindAvatar(view: View, avatar: Avatar)
    {
        val imgAvatar = view.findViewById<ImageView>(R.id.ImgAvatar)
        imgAvatar.setImageResource(avatar.imagen)
    }
}