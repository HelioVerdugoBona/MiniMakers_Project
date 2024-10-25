package com.example.descubrelasestaciones;

import android.content.Context;
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import androidx.recyclerview.widget.RecyclerView

class ItemsEstacionesAdapter(
    private val context: Context,
    private val itemsEstaciones: MutableList<ItemEstaciones>,
    private val itemClickListener: (ItemEstaciones) -> Unit
) : RecyclerView.Adapter<ItemsEstacionesAdapter.ItemsEstacionesViewHolder>()
{

    private val layout = R.layout.item_image

    class ItemsEstacionesViewHolder(val view: View, private val itemClickListener: (ItemEstaciones) -> Unit) :
        RecyclerView.ViewHolder(view)
    {
        var imgItemEstaciones = view.findViewById<ImageView>(R.id.imageView)

        fun bind(item: ItemEstaciones) {
            imgItemEstaciones.setImageResource(item.imagen)
            itemView.setOnClickListener { itemClickListener(item) }
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ItemsEstacionesViewHolder
    {
        val view = LayoutInflater.from(parent.context).inflate(layout, parent, false)
        return ItemsEstacionesViewHolder(view, itemClickListener)
    }

    override fun getItemCount(): Int = itemsEstaciones.size

    override fun onBindViewHolder(holder: ItemsEstacionesViewHolder, position: Int) {
        val itemEstacion = itemsEstaciones[position]
        holder.bind(itemEstacion)
    }
}
