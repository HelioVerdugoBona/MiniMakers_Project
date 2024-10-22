package com.example.descubrelasestaciones;

import android.content.Context;
import android.graphics.BitmapFactory
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import androidx.recyclerview.widget.RecyclerView

class ItemEstacionesAdapter (private val context: Context,
                                      private val itemsEstaciones: MutableList<ItemEstaciones>):
    RecyclerView.Adapter<ItemEstacionesAdapter.ItemsEstacionesViewHolder>()
{

    private val layout = R.layout.colores_estaciones
    class ItemsEstacionesViewHolder(val view: View):
        RecyclerView.ViewHolder(view)
    {
        var imgItemEstaciones: ImageView

        init
        {
            imgItemEstaciones = view.findViewById(R.id.ImgAvatar)
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ItemsEstacionesViewHolder
    {
        val view = LayoutInflater.from(parent.context).inflate(layout, parent, false)

        return ItemsEstacionesViewHolder(view)
    }

    override fun onBindViewHolder(holder: ItemsEstacionesViewHolder, position: Int)
    {
        val itemEstacion = itemsEstaciones[position]

        bindItemEstaciones(holder,itemEstacion)
    }

    fun bindItemEstaciones(holder: ItemsEstacionesViewHolder, itemEstacion: ItemEstaciones)
    {
        val ItemEstacionesPath = context.getFilesDir().toString() + "/img/" + itemEstacion.imagen
        val bitmap = BitmapFactory.decodeFile(ItemEstacionesPath)
        holder.imgItemEstaciones?.setImageBitmap(bitmap)

    }
}