package md5f18ca1d880e4f35b465a152ffd46994e;


public class ParsingUtil_MyListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.lang.Runnable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_run:()V:GetRunHandler:Java.Lang.IRunnableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Plugin.Iconize.Droid.ParsingUtil+MyListener, Plugin.Iconize.Droid, Version=1.0.10.0, Culture=neutral, PublicKeyToken=null", ParsingUtil_MyListener.class, __md_methods);
	}


	public ParsingUtil_MyListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ParsingUtil_MyListener.class)
			mono.android.TypeManager.Activate ("Plugin.Iconize.Droid.ParsingUtil+MyListener, Plugin.Iconize.Droid, Version=1.0.10.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public ParsingUtil_MyListener (android.view.View p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == ParsingUtil_MyListener.class)
			mono.android.TypeManager.Activate ("Plugin.Iconize.Droid.ParsingUtil+MyListener, Plugin.Iconize.Droid, Version=1.0.10.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public void run ()
	{
		n_run ();
	}

	private native void n_run ();

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
