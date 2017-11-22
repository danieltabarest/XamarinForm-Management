package md5f18ca1d880e4f35b465a152ffd46994e;


public class CustomTypefaceSpan
	extends android.text.style.ReplacementSpan
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_draw:(Landroid/graphics/Canvas;Ljava/lang/CharSequence;IIFIIILandroid/graphics/Paint;)V:GetDraw_Landroid_graphics_Canvas_Ljava_lang_CharSequence_IIFIIILandroid_graphics_Paint_Handler\n" +
			"n_getSize:(Landroid/graphics/Paint;Ljava/lang/CharSequence;IILandroid/graphics/Paint$FontMetricsInt;)I:GetGetSize_Landroid_graphics_Paint_Ljava_lang_CharSequence_IILandroid_graphics_Paint_FontMetricsInt_Handler\n" +
			"";
		mono.android.Runtime.register ("Plugin.Iconize.Droid.CustomTypefaceSpan, Plugin.Iconize.Droid, Version=1.0.10.0, Culture=neutral, PublicKeyToken=null", CustomTypefaceSpan.class, __md_methods);
	}


	public CustomTypefaceSpan () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CustomTypefaceSpan.class)
			mono.android.TypeManager.Activate ("Plugin.Iconize.Droid.CustomTypefaceSpan, Plugin.Iconize.Droid, Version=1.0.10.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void draw (android.graphics.Canvas p0, java.lang.CharSequence p1, int p2, int p3, float p4, int p5, int p6, int p7, android.graphics.Paint p8)
	{
		n_draw (p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	private native void n_draw (android.graphics.Canvas p0, java.lang.CharSequence p1, int p2, int p3, float p4, int p5, int p6, int p7, android.graphics.Paint p8);


	public int getSize (android.graphics.Paint p0, java.lang.CharSequence p1, int p2, int p3, android.graphics.Paint.FontMetricsInt p4)
	{
		return n_getSize (p0, p1, p2, p3, p4);
	}

	private native int n_getSize (android.graphics.Paint p0, java.lang.CharSequence p1, int p2, int p3, android.graphics.Paint.FontMetricsInt p4);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
