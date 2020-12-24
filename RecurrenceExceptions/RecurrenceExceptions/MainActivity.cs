using Android.App;
using Android.Widget;
using Android.OS;
using Com.Syncfusion.Schedule;
using Java.Util;
using System.Collections.ObjectModel;
using Android.Graphics;

namespace RecurrenceExceptions
{
    [Activity(Label = "RecurrenceExceptions", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        ScheduleAppointmentCollection scheduleAppointmentCollection = new ScheduleAppointmentCollection();
        Calendar currentDate = Calendar.Instance;
        Button AddExceptionDates;
        Button RemoveExceptionDates;
        Button AddExceptionAppointment;
        Button RemoveExceptionAppointment;
        Calendar exceptionDate3 = Calendar.Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            LinearLayout linearLayout = new LinearLayout(this);
            linearLayout.Orientation = Orientation.Vertical;
            this.AddButton(linearLayout);
            //Creating an instance for SfSchedule Control
            SfSchedule schedule = new SfSchedule(this);
            schedule.ScheduleView = Com.Syncfusion.Schedule.Enums.ScheduleView.WeekView;

            // Creating an instance for schedule appointment Collection

            Calendar startTime = (Calendar)currentDate.Clone();

            //setting start time for the event
            startTime.Set(2017, 08, 03, 10, 0, 0);
            Calendar endTime = (Calendar)currentDate.Clone();

            //setting end time for the event
            endTime.Set(2017, 08, 03, 12, 0, 0);

            // move to date.
            schedule.MoveToDate = startTime;

            // Set exception dates.
            var exceptionDate1 = Calendar.Instance;
            exceptionDate1.Set(2017, 08, 03);
            var exceptionDate2 = Calendar.Instance;
            exceptionDate2.Set(2017, 08, 05);
            exceptionDate3 = Calendar.Instance;
            exceptionDate3.Set(2017, 08, 07);

            ScheduleAppointment recurrenceAppointment = new ScheduleAppointment();
            recurrenceAppointment.Id = 1;
            recurrenceAppointment.StartTime = startTime;
            recurrenceAppointment.EndTime = endTime;
            recurrenceAppointment.Subject = "Daily Occurs";
            recurrenceAppointment.Color = Color.Blue;
            recurrenceAppointment.RecurrenceRule = "FREQ=DAILY;COUNT=20";
            recurrenceAppointment.RecurrenceExceptionDates = new ObservableCollection<Calendar> { exceptionDate1, exceptionDate2, exceptionDate3 };
            scheduleAppointmentCollection.Add(recurrenceAppointment);

            //Adding schedule appointment collection to SfSchedule appointments
            schedule.ItemsSource = scheduleAppointmentCollection;
            linearLayout.AddView(schedule);
            SetContentView(linearLayout);
        }

        private void AddButton(LinearLayout linearLayout)
        {
            AddExceptionDates = new Button(this);
            AddExceptionDates.Text = "AddExceptionDates";
            AddExceptionDates.Click += AddExceptionDates_Click;
            linearLayout.AddView(AddExceptionDates);

            RemoveExceptionDates = new Button(this);
            RemoveExceptionDates.Text = "RemoveExceptionDates";
            RemoveExceptionDates.Click += RemoveExceptionDates_Click;
            linearLayout.AddView(RemoveExceptionDates);

            AddExceptionAppointment = new Button(this);
            AddExceptionAppointment.Text = "AddExceptionAppointment";
            AddExceptionAppointment.Click += AddExceptionAppointment_Click;
            linearLayout.AddView(AddExceptionAppointment);

            RemoveExceptionAppointment = new Button(this);
            RemoveExceptionAppointment.Text = "RemoveExceptionAppointment";
            RemoveExceptionAppointment.Click += RemoveExceptionAppointment_Click;
            linearLayout.AddView(RemoveExceptionAppointment);
        }

        private void RemoveExceptionAppointment_Click(object sender, System.EventArgs e)
        {
            if (scheduleAppointmentCollection.Count > 1)
            {
                var exceptionAppointment = scheduleAppointmentCollection[1];
                scheduleAppointmentCollection.Remove(exceptionAppointment);
            }
        }


        private void AddExceptionAppointment_Click(object sender, System.EventArgs e)
        {
            var startTime1 = Calendar.Instance;
            startTime1.Set(2017, 08, 07, 13, 0, 0);
            var endTime1 = Calendar.Instance;
            endTime1.Set(2017, 08, 07, 14, 0, 0);

            var recurrenceAppointment = scheduleAppointmentCollection[0];
            ScheduleAppointment exceptionAppointment = new ScheduleAppointment();
            exceptionAppointment.StartTime = startTime1;
            exceptionAppointment.EndTime = endTime1;
            exceptionAppointment.Subject = "Daily Occurs";
            exceptionAppointment.Color = Color.Red;
            exceptionAppointment.RecurrenceId = recurrenceAppointment.Id;
            exceptionAppointment.ExceptionOccurrenceActualDate = exceptionDate3;
            scheduleAppointmentCollection.Add(exceptionAppointment);
        }


        private void RemoveExceptionDates_Click(object sender, System.EventArgs e)
        {
            scheduleAppointmentCollection[0].RecurrenceExceptionDates.RemoveAt(0);
        }


        private void AddExceptionDates_Click(object sender, System.EventArgs e)
        {
            Calendar exceptionDate = (Calendar)currentDate.Clone();
            exceptionDate.Set(2017, 08, 08, 10, 0, 0);
            scheduleAppointmentCollection[0].RecurrenceExceptionDates.Add(exceptionDate);
        }

    }
}

