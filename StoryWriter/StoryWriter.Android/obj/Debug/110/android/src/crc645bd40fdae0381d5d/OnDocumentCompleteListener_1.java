package crc645bd40fdae0381d5d;


public class OnDocumentCompleteListener_1
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.tasks.OnCompleteListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onComplete:(Lcom/google/android/gms/tasks/Task;)V:GetOnComplete_Lcom_google_android_gms_tasks_Task_Handler:Android.Gms.Tasks.IOnCompleteListenerInvoker, Xamarin.GooglePlayServices.Tasks\n" +
			"";
		mono.android.Runtime.register ("StoryWriter.Droid.ServiceListeners.OnDocumentCompleteListener`1, StoryWriter.Android", OnDocumentCompleteListener_1.class, __md_methods);
	}


	public OnDocumentCompleteListener_1 ()
	{
		super ();
		if (getClass () == OnDocumentCompleteListener_1.class)
			mono.android.TypeManager.Activate ("StoryWriter.Droid.ServiceListeners.OnDocumentCompleteListener`1, StoryWriter.Android", "", this, new java.lang.Object[] {  });
	}


	public void onComplete (com.google.android.gms.tasks.Task p0)
	{
		n_onComplete (p0);
	}

	private native void n_onComplete (com.google.android.gms.tasks.Task p0);

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
